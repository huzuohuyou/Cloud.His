<template>
  <div class="continer">
    <div class="group-info flex-style group-info-menu">
      <topMenu :menu-list="menuList" @turnUrl="turnUrl"></topMenu>
    </div>
    <div class="single-page-con" :style="{left: shrink?'80px':'256px'}">
      <div class="single-page">
        <Tabs id='tabs' type="card" closable @on-tab-remove="handleTabRemove" :value="currentTab">
          <TabPane v-for="(tab,i) in tabs" :key="tab.title" :label="tab.title" :name="tab.title">
            <component :is="tab.component"></component>
          </TabPane>
        </Tabs>
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
  import axios from "axios";
  @Component({
    components: {
      StationButton,
      shrinkableMenu,
      topMenu
    }
  })
  export default class Prescription extends AbpBase {
    // @Prop({ required: true, type: Array }) menuList: Array<Router>;
    @Prop() defaultView: string;
    // @Prop() father: string;
    currentTab: string = "";
    shrink: boolean = false;
    theme1: string = "primary";
    modal1: boolean = false;

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
    get menuList() {
      let menuList: Array<Router> = []
    axios
      .get("http://capinfo.devops.com:21021/api/services/app/Authority/GetContinerMenu?father="+this.$store.state.app.father+'&userId='+ this.$store.state.session.user.id)
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
         
      })
      .catch(function(error) {
        alert(error);
      });
     
     return menuList;
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
    turnUrl(title: string, component: string) {
      this.currentTab = title;
      if (this.tabs.filter((item, index, array) => {
        return item['title'] == title;
      }).length == 0) {
        this.tabs.push({ title: title, component: component });
      }
    }
    handleTabRemove(name) {
      this.tabs.forEach((val, idx, array) => {
        if (val['title'] == name) {
          this.tabs.splice(idx, 1)
        }
      })

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