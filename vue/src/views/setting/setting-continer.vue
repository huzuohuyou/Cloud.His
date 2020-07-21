<template>
  <div class="continer">
    <SubFormContiner :menuList="menuList" :defaultView="defaultView"></SubFormContiner>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import util from "@/lib/util";
import "viewerjs/dist/viewer.css";
import SubFormContiner from "@/components/common/subform-continer.vue";
import AbpBase from "@/lib/abpbase";
import axios from "axios";
@Component({
  components: {
    SubFormContiner
  }
})
export default class Setting extends AbpBase {
  defaultView: string = "User";

  get menuList() {
      let menuList: Array<Router> = []
    axios
      .get("http://capinfo.devops.com:21021/api/services/app/Authority/GetContinerMenu?father=1003")
      .then(function(response) {
         
         for (let value2 of response.data.result) {
             let item: Router = {
                    'path': value2.path,
                    'name': value2.componentName,
                    'componentName': value2.componentName,
                    'menuIcon': value2.menuIcon,
                    'permission': '',
                    'sub': true,
                    'meta': { 'title': value2.title, 'keepAlive': false },
                    'icon': '&#xe68a;',
                    'component': ''
                }
                if (value2.children.length > 0) {
                    item.children = new Array<Router>()
                    for (let value3 of value2.children) {
                        let item1: Router = {
                            'path': value3.path,
                            'name': value3.componentName,
                            'componentName': value3.componentName,
                            'menuIcon': value3.menuIcon,
                            'permission': '',
                            'sub': true,
                            'meta': { 'title': value3.title, 'keepAlive': false },
                            'icon': '&#xe68a;',
                            'component': ''
                        }
                        item.children.push(item1)
                    }
                }
                
                menuList.push(item)
         }
         console.log('menuList')
         console.log(menuList)
      })
      .catch(function(error) {
        alert(error);
      });
     
     return menuList;
  }
}
</script>
<style>
.continer {
  height: 98%;
  padding: 0px;
  background-color: #2d8cf000;
}
</style>