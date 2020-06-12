<template>
    <div style="height: 100px;" @click="modal7 = true">
        <StationButton :key="item.id" :title='item.title' :imageUrl='item.url' :backgroundColor='item.backgroundColor'>
        </StationButton>
        <Modal width="900px" title="选择患者" v-model="modal7" :closable="false">
            <div>
                <div class="select-patient-continer ">
                    <Row>
                        <Col span="2" class="label">诊疗科室：</Col>
                        <Col span="4"><Input  placeholder="Enter something..." /></Col>
                        <Col span="2" class="label">诊疗医生：</Col>
                        <Col span="4"><Input  placeholder="Enter something..." /></Col>
                        <Col span="2" class="label">选择患者：</Col>
                        <Col span="4"><Input  placeholder="Enter something..." /></Col>
                        <Col span="2" class="label">医嘱日期：</Col>
                        <Col span="4"><Input  placeholder="Enter something..." /></Col>

                    </Row>
                    <Row>
                        <Col span="2" class="label">挂号总数：</Col>
                        <Col span="4"><Input  placeholder="Enter something..." /></Col>
                        <Col span="2" class="label">等待诊疗：</Col>
                        <Col span="4"><Input  placeholder="Enter something..." /></Col>
                        <Col span="2" class="label">结束诊疗：</Col>
                        <Col span="4"><Input  placeholder="Enter something..." /></Col>
                        <Col span="2" class="label">其他：</Col>
                        <Col span="4"><Input  placeholder="Enter something..." /></Col>

                    </Row>
                </div>
                <div>
                    <Table highlight-row width="860" height="400" :columns="columns1" :data="data2"></Table>
                </div>
            </div>
        </Modal>
    </div>
</template>
<script>
    import 'viewerjs/dist/viewer.css'
    import StationButton from "@/components/common/icon-on-button-top.vue";
    import Viewer from "v-viewer/src/component.vue"
    export default {
        components: {
            StationButton,
        },
        data() {
            return {
                item: { id: 1, title: "查找患者", url: require('../../assets/images/查找.png'), backgroundColor: { background: '#FF9966' } },
                modal7: false,
                modal8: false,
                columns1: [
                    {
                        title: '患者编号',
                        key: 'name',
                        fixed: 'left',
                        width: 100
                    },
                    {
                        title: '姓名',
                        key: 'age',
                        width: 100
                    },
                    {
                        title: '性别/年龄',
                        key: 'age',
                        width: 100
                    },
                    {
                        title: '初/再诊',
                        key: 'age',
                        width: 100
                    },
                    {
                        title: '保险区分',
                        key: 'age',
                        width: 100
                    },
                    {
                        title: '挂号区分',
                        key: 'age',
                        width: 100
                    },
                    {
                        title: '联系电话',
                        key: 'age',
                        width: 100
                    },
                    {
                        title: '最近来院科室',
                        key: 'age',
                        width: 150
                    }
                    ,
                    {
                        title: '最近来院时间',
                        key: 'age',
                        width: 150
                    },
                    {
                        title: '其他挂号内容',
                        key: 'age',
                        width: 150
                    }
                ],
                data2: [
                    {
                        name: 'John Brown',
                        age: 18,
                        address: 'New York No. 1 Lake Park',
                        date: '2016-10-03'
                    },
                    {
                        name: 'Jim Green',
                        age: 24,
                        address: 'London No. 1 Lake Park',
                        date: '2016-10-01'
                    },
                    {
                        name: 'Joe Black',
                        age: 30,
                        address: 'Sydney No. 1 Lake Park',
                        date: '2016-10-02'
                    },
                    {
                        name: 'Jon Snow',
                        age: 26,
                        address: 'Ottawa No. 2 Lake Park',
                        date: '2016-10-04'
                    },
                    {
                        name: 'John Brown',
                        age: 18,
                        address: 'New York No. 1 Lake Park',
                        date: '2016-10-03'
                    },
                    {
                        name: 'Jim Green',
                        age: 24,
                        address: 'London No. 1 Lake Park',
                        date: '2016-10-01'
                    },
                    {
                        name: 'Joe Black',
                        age: 30,
                        address: 'Sydney No. 1 Lake Park',
                        date: '2016-10-02'
                    },
                    {
                        name: 'Jon Snow',
                        age: 26,
                        address: 'Ottawa No. 2 Lake Park',
                        date: '2016-10-04'
                    }
                ]
            }
        }
    }
</script>
<style>
    .select-patient-continer {
        background-color: white;
        border-radius: 10px;
        padding: 10px;
        padding-top: 0px;
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        height: 120px;
        margin-top: 5px;
    }

    .label {
        /* padding-top: 5px; */
    }
</style>