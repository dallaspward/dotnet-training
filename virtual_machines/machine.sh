#!/bin/sh
​
## configuration :: docker
apt update
​
apt install --yes \
  apt-transport-https \
  ca-certificates \
  curl \
  gnupg-agent \
  software-properties-common
​
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | apt-key add -
​
add-apt-repository \
  "deb [arch=amd64] https://download.docker.com/linux/ubuntu \
  $(lsb_release -cs) stable"
​
apt update
​
apt install --yes \
  docker-ce \
  containerd.io
​
usermod -aG docker vagrant
newgrp docker




