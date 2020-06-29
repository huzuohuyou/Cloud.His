<template>
    <div class="continer">
        <div class="group-info flex-style group-info-menu">
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
        </div>
       
        <div class="group-info flex-style ">
            <OutpatientInfo></OutpatientInfo>
        </div>

        <div class="group-info ">
            <Table height="200" :columns="columns1" :data="data2"></Table>
        </div>
        <div class="group-info flex-style">
           
            <SelectPatient2></SelectPatient2>
            <SelectOrder></SelectOrder>
            <SelectDiagnosis></SelectDiagnosis>
           
        </div>
        <div class="group-info" >
            <Table height="530" :columns="columns2" :data="data2"></Table>
        </div>
        
    </div>
</template>
<script>
    import 'viewerjs/dist/viewer.css'
    import StationButton from "@/components/common/icon-on-button-top.vue";
    import OrderButton from "@/components/common/icon-on-button-right.vue";
    import OutpatientInfo from "@/components/outpatient/outpatient-info.vue";
    import SelectPatient from "@/components/outpatient/select-patient.vue";
    import SelectPatient2 from "@/components/outpatient/select-patient2.vue";
    import SelectOrder from "@/components/order/select-order.vue";
    import SelectDiagnosis from "@/components/diagnosis/select-diagnosis.vue";
    export default {
        // selectModalShow: Boolean = false,
        components: {
            StationButton,
            OrderButton,
            OutpatientInfo,
            SelectPatient,
            SelectPatient2,
            SelectOrder,
            SelectDiagnosis
        },
        data() {
            return {
                theme1: 'primary',
                modal1: false,
                imgList: [
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
                ]
                , imgList2: [
                    { id: 11, title: "删除医保", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#FF9966' } },
                    { id: 12, title: "删除疾病", url: require('../../assets/images/病例.png'), backgroundColor: { background: '#FF9999' } },
                    { id: 13, title: "医嘱重排", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#CCCC00' } },
                    { id: 14, title: "取消选择", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#0099CC' } },
                    { id: 15, title: "其他作业", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#99CC66' } },
                ]
                , columns1: [
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
                , data2: [
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
                , columns2: [
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
                ],
            }
        },
        methods: {
            ok() {
                this.$Message.info('Clicked ok');
            },
            cancel() {
                this.$Message.info('Clicked cancel');
            },
            inited(viewer) {
                this.$viewer = viewer
            },
            show() {
                this.$viewer.show()
            },
            select() {
                alert('haha')
                // this.selectModalShow = true;
            }, sayHello() {
                alert('haha')
            }
        }
    }
</script>
<style>
    .continer {
        height: 98%;
        padding: 0px;
        background-color:#2d8cf000;
    }
    
    .group-info {
        background-color:white;
        border-radius: 10px;
        margin: 0 0 10px;
        padding: 0 10px ;
    }

    .group-info-menu {
        
        padding: 0px ;
    }

    .flex-style{
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
    }
    .ivu-menu-primary {
     width: 100%!important;  
}
</style>