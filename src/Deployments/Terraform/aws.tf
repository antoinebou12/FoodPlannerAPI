provider "aws" {
  region = "us-west-2"
}

locals {
  cluster_name = "my-cluster"
}

data "aws_availability_zones" "available" {}

module "eks" {
  source          = "terraform-aws-modules/eks/aws"
  cluster_name    = local.cluster_name
  cluster_version = "1.20"
  subnets         = ["subnet-abcde012", "subnet-bcde012a", "subnet-fghi345a"]
  vpc_id          = "vpc-abcde012"

  node_groups = {
    eks_nodes = {
      desired_capacity = 2
      max_capacity     = 10
      min_capacity     = 1

      instance_type = "m5.large"
      key_name      = "my-key-name"

      root_volume_size = 100
      root_volume_type = "gp2"

      source_security_group_ids = ["sg-0123456789abcdef0"]
    }
  }
}

provider "kubernetes" {
  host                   = module.eks.cluster_endpoint
  cluster_ca_certificate = base64decode(module.eks.cluster_certificate_authority_data)
  token                  = module.eks.kubeconfig.token
  load_config_file       = false
  version                = "~> 2.20.0"
}

resource "kubernetes_namespace" "recipemicroservice" {
  metadata {
    name = "recipemicroservice"
  }
}

resource "kubernetes_secret" "db-creds" {
  metadata {
    name      = "db-creds"
    namespace = kubernetes_namespace.recipemicroservice.metadata.name
  }

  data = {
    connectionstring = "Server=db;Database=recipedb;User=sa;Password=Your_password123;"
  }
}

locals {
  kubectl_manifests = [
    {
      apiVersion = "apps/v1"
      kind       = "Deployment"
      metadata = {
        name      = "recipemicroservice"
        namespace = kubernetes_namespace.recipemicroservice.metadata.name
      }
      spec = {
        replicas = 3
        selector = {
          matchLabels = {
            app = "recipemicroservice"
          }
        }
        template = {
          metadata = {
            labels = {
              app = "recipemicroservice"
            }
          }
          spec = {
            containers = [
              {
                name  = "recipemicroservice"
                image = "recipemicroservice:latest"
                ports = [
                  {
                    containerPort = 80
                  },
                ]
                env = [
                  {
                    name = "ConnectionStrings__DefaultConnection"
                    valueFrom = {
                      secretKeyRef = {
                        name = kubernetes_secret.db-creds.metadata.name
                        key  = "connectionstring"
                      }
                    }
                  },
                ]
              },
            ]
          }
        }
      }
    },
    {
      apiVersion = "v1"
      kind       = "Service"
      metadata = {
        name      = "recipemicroservice"
        namespace = kubernetes_namespace.recipemicroservice.metadata.name
      }
      spec = {
        selector = {
          app = "recipemicroservice"
        }
        ports = [
          {
            port        = 80
            targetPort  = 80
            protocol    = "TCP"
            name        = "http"
          },
        ]

        type = "LoadBalancer"
      }
    },
  ]
}

resource "kubernetes_manifest" "kubectl" {
  for_each   = { for manifest in local.kubectl_manifests : "${manifest.kind}/${manifest.metadata.name}" => manifest }
  manifest   = each.value
}

