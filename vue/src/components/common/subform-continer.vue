<template>
  <div class="continer">
    <div class="group-info flex-style group-info-menu">
      <topMenu :menu-list="menuList" @turnUrl="turnUrl"></topMenu>
    </div>
    <div class="single-page-con" :style="{left: shrink?'80px':'256px'}">
      <div class="single-page">
        <Tabs id='tabs' type="card" closable @on-tab-remove="handleTabRemove" >
          <TabPane v-for="(tab,i) in tabs" :key="tab.title" :label="tab.title">
            <component :is="tab.component"></component>
          </TabPane>
          </TabPane>
        </Tabs>
        <!-- <router-view :name="continer"></router-view> -->
      </div>
    </div>
  </div>
</template>
<script lang="ts">
  import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
  import util from "@/lib/util";
  import "viewerjs/dist/viewer.css";
  import StationButton from "@/components/common/icon-on-button-top.vue";

  import shrinkableMenu from "@/components/shrinkable-menu/shrinkable-menu.vue";
  import topMenu from "@/components/common/top-menu.vue";
  import AbpBase from "@/lib/abpbase";
  @Component({
    components: {
      StationButton,
      shrinkableMenu,
      topMenu
    }
  })
  export default class Prescription extends AbpBase {
    @Prop({ required: true, type: Array }) menuList: Array<Router>;
    @Prop() defaultView: string;

    shrink: boolean = false;
    theme1: string = "primary";
    modal1: boolean = false;
    continer: string = "continer";
    tab0: boolean = true;
    tab1: boolean = true;
    tab2: boolean = true;
    tabs: Array<Object> = [];
    currentComponent: string = "Authority";
    get userName() {
      return this.$store.state.session.user
        ? this.$store.state.session.user.name
        : "";
    }
    isFullScreen: boolean = false;
    messageCount: string = "0";
    get openedSubmenuArr() {
      return this.$store.state.app.openedSubmenuArr;
    }

    get pageTagsList() {
      return this.$store.state.app.pageOpenedList as Array<any>;
    }
    get currentPath() {
      return this.$store.state.app.currentPath;
    }
    get lang() {
      return this.$store.state.app.lang;
    }
    get avatorPath() {
      return localStorage.avatorImgPath;
    }
    get cachePage() {
      return this.$store.state.app.cachePage;
    }
    get menuTheme() {
      return this.$store.state.app.menuTheme;
    }
    get mesCount() {
      return this.$store.state.app.messageCount;
    }
    turnUrl(title: string,component: string) {
      console.log({title:title,component:component})
      this.tabs.push({title:title,component:component});
      //{path:path,title:'a',component:'Authority'}
    }
    handleTabRemove(name) {
      console.log(name)
      // this.tabs.pop(name)
      this["tab" + name] = false;
    }
    init() {
      let pathArr = util.setCurrentPath(this, this.$route.name as string);
      this.$store.commit("app/updateMenulist");
      if (pathArr.length >= 2) {
        this.$store.commit("app/addOpenSubmenu", pathArr[1].name);
      }
      let messageCount = 3;
      this.messageCount = messageCount.toString();
      this.checkTag(this.$route.name);
    }
    toggleClick() {
      this.shrink = !this.shrink;
    }
    handleClickUserDropdown(name: string) {
      if (name === "ownSpace") {
        util.openNewPage(this, "ownspace_index", null, null);
        this.$router.push({
          name: "ownspace_index"
        });
      } else if (name === "loginout") {
        this.$store.commit("app/logout", this);
        util.abp.auth.clearToken();
        location.reload();
      }
    }
    checkTag(name?: string) {
      let openpageHasTag = this.pageTagsList.some((item: any) => {
        if (item.name === name) {
          return true;
        } else {
          return false;
        }
      });
      if (!openpageHasTag) {
        util.openNewPage(
          this,
          name as string,
          this.$route.params || {},
          this.$route.query || {}
        );
      }
    }
    handleSubmenuChange(val: string) {
      // console.log(val)
    }
    beforePush(name: string) {
      if (name === "accesstest_index") {
        return false;
      } else {
        return true;
      }
    }
    fullscreenChange(isFullScreen: boolean) {
      // console.log(isFullScreen);
    }
    @Watch("$route")
    routeChange(to: any) {
      this.$store.commit("app/setCurrentPageName", to.name);
      let pathArr = util.setCurrentPath(this, to.name);

      if (pathArr.length > 2) {
        this.$store.commit("app/addOpenSubmenu", pathArr[1].name);
      }
      this.checkTag(to.name);
      localStorage.currentPageName = to.name;
    }
    @Watch("lang")
    langChange() {
      util.setCurrentPath(this, this.$route.name as string);
    }
    mounted() {
      this.init();
    }
    updateRouter(router: string) {
      // this.$router.push({ path: router })
    }
    created() {
      //默认首页
      // this.$router.push({ path: this.defaultView })
      // this.$store.commit('app/setOpenedList');
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