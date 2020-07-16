<template>
  <Menu mode="horizontal" :theme="theme1" active-name="1">
    <MenuItem name="1">
    <Icon type="ios-paper" />
    内容管理
    </MenuItem>
    <MenuItem name="2">
    <Icon type="ios-people" />
    用户管理
    </MenuItem>
    <Submenu name="3">
      <template slot="title">
        <Icon type="ios-stats" />
        统计分析
      </template>
      <MenuGroup title="使用">
        <MenuItem name="3-1">新增和启动</MenuItem>
        <MenuItem name="3-2">活跃分析</MenuItem>
        <MenuItem name="3-3">时段分析</MenuItem>
      </MenuGroup>
      <MenuGroup title="留存">
        <MenuItem name="3-4">用户留存</MenuItem>
        <MenuItem name="3-5">流失用户</MenuItem>
      </MenuGroup>
    </Submenu>
    <MenuItem name="4">
    <Icon type="ios-construct" />
    综合设置
    </MenuItem>
  </Menu>
</template>
<script lang="ts">
  import { Component, Vue, Inject, Prop, Watch } from 'vue-property-decorator';
  import util from '@/lib/util';
  import 'viewerjs/dist/viewer.css'

  import AbpBase from '@/lib/abpbase'

  @Component({
    components: { }
  })
  export default class Prescription extends AbpBase {
    @Prop({ required: true, type: Array }) menuList: Array<any>;
    @Prop() defaultView: string;

    theme1: String = "primary"

    mounted() {
    }
    created() {
      
    }

  }

</script>
<style>
  .continer {
    height: 98%;
    padding: 0px;
    background-color: #2d8cf000;
  }

  .group-info {
    background-color: white;
    border-radius: 10px;
    margin: 0 0 10px;
    padding: 0 10px;
  }

  .group-info-menu {

    padding: 0px;
  }

  .flex-style {
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
  }

  .ivu-menu-primary {
    width: 100% !important;
  }
</style>