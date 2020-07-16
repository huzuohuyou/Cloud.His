<template>
  <Menu mode="horizontal" :theme="theme1" active-name="1"  @on-select="turnUrl">
    <div v-for="(item, i) in menuList">
      <MenuItem v-if="item.children.length ==0" name="item.name">
      <Icon type="item.icon" />
      {{item.title}}
      </MenuItem>
      <Submenu v-else name="item.name">
        <template slot="title">
          <Icon type="item.menuIcon" />
          {{item.title}}
        </template>
        <MenuItem v-for="(child, j) in item.children"  :name="child.path">{{child.title}}</MenuItem>
      </Submenu>
    </div>


  </Menu>
</template>
<script lang="ts">
  import { Component, Vue, Inject, Prop, Watch } from 'vue-property-decorator';
  import util from '@/lib/util';
  import 'viewerjs/dist/viewer.css'
  import AbpBase from '@/lib/abpbase'

  @Component({
    components: {}
  })
  export default class Prescription extends AbpBase {
    @Prop({ required: true, type: Array }) menuList: Array<any>;
    @Prop() defaultView: string;

    theme1: String = "primary"
    turnUrl(path:string) {
      this.$router.push({path:path})

    }
    mounted() {
    }
    created() {

    }

  }

</script>