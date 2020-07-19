<template>
  <Menu mode="horizontal" :theme="theme1" active-name="1" @on-select="turnUrl">
    
    <div v-for="(item, i) in tempMenu" :key="i">
      <MenuItem v-if="item.children.length ==0" :name="item.path">
        <Icon type="item.menuIcon" />{{item.meta.title}}
        <!-- <router-link :to="item.path">{{item.meta.title}}</router-link> -->
      </MenuItem>
      <Submenu v-else name="item.name">
        <template slot="title">
          <Icon :type="item.menuIcon" />
          {{item.meta.title}}
        </template>
        <MenuItem
          v-for="(child, j) in item.children"
          :name="child.path"
          :key="j"
        >{{child.meta.title}}
         <!-- <router-link :to="child.path">{{child.meta.title}}</router-link> -->
        </MenuItem>
      </Submenu>
    </div>
  </Menu>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import util from "@/lib/util";
import "viewerjs/dist/viewer.css";
import AbpBase from "@/lib/abpbase";

@Component({
  components: {}
})
export default class Prescription extends AbpBase {
  @Prop({ required: true, type: Array }) menuList: Array<Router>;
  @Prop() defaultView: string;
 tempMenu :Array<Router>=[];
  theme1: String = "primary";
  turnUrl(path: string) {
    this.$emit('turnUrl',path);
  
  }
  mounted() {
    this.tempMenu=this.menuList;

  }
  created() {
  
  }
}
</script>