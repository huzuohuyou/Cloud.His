<template>
    <div class="continer">
        <div class="group-info flex-style group-info-menu">
            <shrinkable-menu :shrink="shrink" @on-change="handleSubmenuChange" :theme="menuTheme"
                :before-push="beforePush" :open-names="openedSubmenuArr" :menu-list="menuList">
                <!-- <div slot="top" class="logo-con">
                    <a>
                        <Icon type="cube" size="32"></Icon>
                        <h1>{{L('AppName')}}</h1>
                    </a>

                </div> -->
            </shrinkable-menu>
           
        </div>
        <div class="single-page-con" :style="{left: shrink?'80px':'256px'}">
            <div class="single-page">
                <keep-alive :include="cachePage" >
                    <router-view ></router-view>
                </keep-alive>                
            </div>
            <!-- <copyfooter :copyright="L('CopyRight')"></copyfooter> -->
        </div>
      
    </div>
</template>
<script lang="ts">
    import { Component, Vue, Inject, Prop, Watch } from 'vue-property-decorator';
    import util from '@/lib/util';
    import 'viewerjs/dist/viewer.css'
    import StationButton from "@/components/common/icon-on-button-top.vue";
    import OrderButton from "@/components/common/icon-on-button-right.vue";
    import OutpatientInfo from "@/views/outpatient/outpatient-info.vue";
    import SelectPatient from "@/views/outpatient/select-patient.vue";
    import SelectPatient2 from "@/views/outpatient/select-patient2.vue";
    import SelectOrder from "@/components/order/select-order.vue";
    import SelectDiagnosis from "@/components/diagnosis/select-diagnosis.vue";
    import shrinkableMenu from '@/components/shrinkable-menu/shrinkable-menu.vue';
    import AbpBase from '@/lib/abpbase'

    @Component({
        components: {
            StationButton,
            OrderButton,
            OutpatientInfo,
            SelectPatient,
            SelectPatient2,
            SelectOrder,
            SelectDiagnosis,
            shrinkableMenu
        }
    })
    export default class Prescription extends AbpBase {
        shrink:boolean=false;
        theme1: String = "primary"
        modal1: Boolean = false;
        imgList: Array<Object> = [
            { id: 1, title: "查找患者", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#FF9966' }, modal: "sayHello" },
            { id: 2, title: "电子病历", url: require('../../assets/images/病例.png'), backgroundColor: { background: '#FF9999' } },
            { id: 3, title: "选择疾病", url: require('../../assets/images/诊断.png'), backgroundColor: { background: '#CCCC00' } },
            { id: 4, title: "选择处方", url: require('../../assets/images/处方.png'), backgroundColor: { background: '#0099CC' } },
            { id: 5, title: "标准处方", url: require('../../assets/images/报告.png'), backgroundColor: { background: '#99CC66' } },
            { id: 6, title: "传送处方", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#FFCCCC' } },
            { id: 7, title: "以前处方", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#CCCCFF' } },
            { id: 8, title: "常用语句", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#FFCCCC' } },
            { id: 9, title: "特殊事项", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#CCCCCC' } },
            { id: 10, title: "计算处方", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#996699' } },
        ];
        imgList2: Array<Object> = [
            { id: 11, title: "删除医保", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#FF9966' } },
            { id: 12, title: "删除疾病", url: require('../../assets/images/病例.png'), backgroundColor: { background: '#FF9999' } },
            { id: 13, title: "医嘱重排", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#CCCC00' } },
            { id: 14, title: "取消选择", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#0099CC' } },
            { id: 15, title: "其他作业", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#99CC66' } },
        ]
        columns1: Array<Object> = [
            {
                title: '发生日期',
                key: 'date',
                width: 170,
                fixed: 'left',
            },
            {
                title: '疾病编码',
                key: 'ill',
                width: 170,

            },
            {
                title: '问题及诊断',
                key: 'age',
                width: 170,
            },
            {
                title: '是否打印',
                key: 'age',
                width: 100
            },
            {
                title: '主疾病',
                key: 'age',
                width: 100
            },
            {
                title: '是否确诊',
                key: 'age',
                width: 120
            },
            {
                title: '是否结束',
                key: 'age',
                width: 120
            },
            {
                title: '结束日期',
                key: 'date',
                width: 120
            },
            {
                title: '医生',
                key: 'age',
                width: 170
            }
        ]
        data2: Array<Object> = [
            {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }
            , {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }, {
                name: 'John Brown',
                age: 18,
                address: 'New York No. 1 Lake Park',
                date: '2016-10-03'
            }
        ]
        columns2: Array<Object> = [
            {
                title: '序号',
                key: 'age',
                width: 70,
                fixed: 'left',
            },
            {
                title: '区分',
                key: 'ill',
                width: 70,
                fixed: 'left',
            },
            {
                title: '医嘱名称',
                key: 'age',
                width: 500
            },
            {
                title: '药品用法/检验标本',
                key: 'age',
                width: 170
            },
            {
                title: '单次剂量总量',
                key: 'age',
                width: 100
            },
            {
                title: '单位',
                key: 'age',
                width: 70
            },
            {
                title: '单次数量',
                key: 'age',
                width: 70
            },
            {
                title: '次数',
                key: 'age',
                width: 70
            },
            {
                title: '日数',
                key: 'age',
                width: 70
            }
            ,
            {
                title: '急诊',
                key: 'age',
                width: 70
            },
            {
                title: '预防治疗',
                key: 'age',
                width: 70
            },
            {
                title: '参保',
                key: 'age',
                width: 70
            },
            {
                title: '备注',
                key: 'age',
                width: 70
            },
            {
                title: '新规',
                key: 'age',
                width: 70
            },
            {
                title: '状态',
                key: 'age',
                width: 70
            },
            {
                title: '可用天数',
                key: 'age',
                width: 70
            },
            {
                title: '传送部门',
                key: 'age',
                width: 70
            },
            {
                title: '单价',
                key: 'age',
                width: 70
            }
        ];
        get userName(){
        return this.$store.state.session.user?this.$store.state.session.user.name:''
      }
      isFullScreen:boolean=false;
      messageCount:string='0';
      get openedSubmenuArr(){
        return this.$store.state.app.openedSubmenuArr
      }
      get menuList () {
        return this.$store.state.app.menuList;
      }
      get pageTagsList () {
        return this.$store.state.app.pageOpenedList as Array<any>;
      }
      get currentPath () {
        return this.$store.state.app.currentPath;
      }
      get lang(){
        return this.$store.state.app.lang;
      }
      get avatorPath () {
        return localStorage.avatorImgPath;
      }
      get cachePage () {
        return this.$store.state.app.cachePage;
      }
      get menuTheme () {
        return this.$store.state.app.menuTheme;
      }
      get mesCount () {
        return this.$store.state.app.messageCount;
      }
      init () {
        let pathArr = util.setCurrentPath(this, this.$route.name as string);
        this.$store.commit('app/updateMenulist');
        if (pathArr.length >= 2) {
          this.$store.commit('app/addOpenSubmenu', pathArr[1].name);
        }
        let messageCount = 3;
        this.messageCount = messageCount.toString();
        this.checkTag(this.$route.name);
      }
      toggleClick () {
        this.shrink = !this.shrink;
      }
      handleClickUserDropdown (name:string) {
        if (name === 'ownSpace') {
          util.openNewPage(this, 'ownspace_index',null,null);
          this.$router.push({
            name: 'ownspace_index'
          });
        } else if (name === 'loginout') {
          this.$store.commit('app/logout', this);
          util.abp.auth.clearToken();
          location.reload();
        }
      }
      checkTag (name?:string) {
        let openpageHasTag = this.pageTagsList.some((item:any) => {
          if (item.name === name) {
            return true;
          }else{
            return false
          }
        });
        if (!openpageHasTag) { 
          util.openNewPage(this, name as string, this.$route.params || {}, this.$route.query || {});
        }
      }
      handleSubmenuChange (val:string) {
        // console.log(val)
      }
      beforePush (name:string) {
        if (name === 'accesstest_index') {
          return false;
        } else {
          return true;
        }
      }
      fullscreenChange (isFullScreen:boolean) {
              // console.log(isFullScreen);
      }
      @Watch('$route')
      routeChange(to:any){
        this.$store.commit('app/setCurrentPageName', to.name);
        let pathArr = util.setCurrentPath(this, to.name);
        if (pathArr.length > 2) {
          this.$store.commit('app/addOpenSubmenu', pathArr[1].name);
        }
        this.checkTag(to.name);
        localStorage.currentPageName = to.name;
      }
      @Watch('lang')
      langChange(){
        util.setCurrentPath(this, this.$route.name as string);
      }
      mounted () {
          this.init();
      }
      created () {
          this.$store.commit('app/setOpenedList');
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