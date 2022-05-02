
`Drone CI` 插件

根据package.json 文件 version 属性自动生成镜像版本号


示例:
```yml
  - name: build-tags
    image: yxs970707/drone-web-tags:latest  
    settings:
      tags:
        - latest    #添加其余版本号
```