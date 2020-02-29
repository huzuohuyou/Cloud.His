import Vue from 'vue';
import App from './app.vue';
import iView from 'iview';
import {router} from './router/index';
import 'famfamfam-flags/dist/sprite/famfamfam-flags.css';
import './theme.less';
import Ajax from './lib/ajax';
import Util from './lib/util';
import SignalRAspNetCoreHelper from './lib/SignalRAspNetCoreHelper';
Vue.use(iView);
import layer from 'vue-layer';
Vue.prototype.$layer = layer(Vue);

import Viewer from 'v-viewer'
import 'viewerjs/dist/viewer.css'
Vue.use(Viewer);
Viewer.setDefaults({
    'inline':true,
    'button':true, //右上角按钮
    "navbar": true, //底部缩略图
    "title": true, //当前图片标题
    "toolbar": true, //底部工具栏
    "tooltip": true, //显示缩放百分比
    "movable": true, //是否可以移动
    "zoomable": true, //是否可以缩放
    "rotatable": true, //是否可旋转
    "scalable": true, //是否可翻转
    "transition": true, //使用 CSS3 过度
    "fullscreen": true, //播放时是否全屏
    "keyboard": true, //是否支持键盘
    "url": "data-source",
    "zIndexInline": 9999,


    ready: function (e) {
      console.log(e.type,'组件以初始化');
    },
    show: function (e) {
      console.log(e.type,'图片显示开始');
    },
    shown: function (e) {
      console.log(e.type,'图片显示结束');
    },
    hide: function (e) {
      console.log(e.type,'图片隐藏完成');
    },
    hidden: function (e) {
      console.log(e.type,'图片隐藏结束');
    },
    view: function (e) {
      console.log(e.type,'视图开始');
    },
    viewed: function (e) {
      console.log(e.type,'视图结束');
      // 索引为 1 的图片旋转20度
      // if(e.detail.index === 1){
      //     this.view.rotate(20);
      // }
    },
    zoom: function (e) {
      console.log(e.type,'图片缩放开始');
    },
    zoomed: function (e) {
      console.log(e.type,'图片缩放结束');
    }
  });

import store from './store/index';
Vue.config.productionTip = false;
import { appRouters,otherRouters} from './router/router';
if(!abp.utils.getCookieValue('Abp.Localization.CultureName')){
  let language=navigator.language;
  abp.utils.setCookieValue('Abp.Localization.CultureName',language,new Date(new Date().getTime() + 5 * 365 * 86400000),abp.appPath);
}

Ajax.get('/AbpUserConfiguration/GetAll').then(data=>{
  Util.abp=Util.extend(true,Util.abp,data.data.result);
  new Vue({
    render: h => h(App),
    router:router,
    store:store,
    data: {
      currentPageName: ''
    },
    async mounted () {
      this.currentPageName = this.$route.name as string;
      await this.$store.dispatch({
        type:'session/init'
      })
      if(!!this.$store.state.session.user&&this.$store.state.session.application.features['SignalR']){
        if (this.$store.state.session.application.features['SignalR.AspNetCore']) {
            SignalRAspNetCoreHelper.initSignalR();
        }
      }
      this.$store.commit('app/initCachepage');
      this.$store.commit('app/updateMenulist');
    },
    created () {
      let tagsList:Array<any> = [];
      appRouters.map((item) => {
          if (item.children.length <= 1) {
              tagsList.push(item.children[0]);
          } else {
              tagsList.push(...item.children);
          }
      });
      this.$store.commit('app/setTagsList', tagsList);
    }
  }).$mount('#app')
})

