<template>
    <!-- <div style="height: 100px;" @click="modal7 = true"> -->
        <div style="margin: auto 0;margin-left: 10px;" @click="modal7 = true">
        <Button type="primary" icon="ios-search">选择处方</Button>
        <!-- <StationButton :key="item.id" :title='item.title' :imageUrl='item.url' :backgroundColor='item.backgroundColor'>
        </StationButton> -->
        <Modal width="900px" title="选择处方" v-model="modal7" :closable="false">
            <div>
                <div >
                    <Row style="width: 100%;">
                        <Col span="3" class="label">查询医嘱</Col>
                        <Col span="3" class="label"><Radio v-model="single">名称(中文)</Radio></Col>
                        <Col span="3" class="label"><Radio v-model="single">成分(药品)</Radio></Col>
                        <Col span="3" class="label"><Radio v-model="single">价格编码</Radio></Col>
                        <Col span="3" class="label"><Radio v-model="single">项目单价</Radio></Col>
                        <Col span="3" class="label"><Radio v-model="single">查询编码</Radio></Col>
                        <Col span="6"><Input  placeholder="Enter something..." /></Col>

                    </Row>
                    
                </div>
                <div style="margin-top: 10px;">
                    <Row>
                        <Col span="6" >
                            <!-- <Table row-key="id" :columns="columns16" :data="data12" border></Table> -->
                            <Tree :data="data1"></Tree>
                        </Col>
                        <Col span="18">
                            <Table highlight-row width="650" height="400" :columns="columns1" :data="data2"></Table>
            
                        </Col>
                       
                    </Row>
                    <!-- <Table row-key="id" :columns="columns16" :data="data12" border></Table> -->
                    <!-- <Table highlight-row width="860" height="400" :columns="columns1" :data="data2"></Table> -->
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
                single:false,
                item: { id: 1, title: "选择处方", url: require('../../assets/images/病例.png'), backgroundColor: { background: '#FF9999' } },
                modal7: false,
                modal8: false,
                columns1: [
                    {
                        title: '医嘱名称',
                        key: 'name',
                        fixed: 'left',
                        width: 300
                    },
                    {
                        title: '单价',
                        key: 'age',
                        width: 100
                    },
                    {
                        title: '参保',
                        key: 'age',
                        width: 100
                    },
                    {
                        title: '新规',
                        key: 'age',
                        width: 100
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
                ,data1: [
                    {
                        title: 'parent 1',
                        expand: true,
                        children: [
                            {
                                title: 'parent 1-1',
                                expand: true,
                                children: [
                                    {
                                        title: 'leaf 1-1-1'
                                    },
                                    {
                                        title: 'leaf 1-1-2'
                                    }
                                ]
                            },
                            {
                                title: 'parent 1-2',
                                expand: true,
                                children: [
                                    {
                                        title: 'leaf 1-2-1'
                                    },
                                    {
                                        title: 'leaf 1-2-1'
                                    }
                                ]
                            }
                        ]
                    }
                ]
                ,columns16: [
                    {
                        title: 'Name',
                        key: 'name',
                        tree: true
                    },
                    {
                        title: 'Age',
                        key: 'age'
                    },
                    {
                        title: 'Address',
                        key: 'address'
                    }
                ],
                data12: [
                    {
                        id: '100',
                        name: 'John Brown',
                        age: 18,
                        address: 'New York No. 1 Lake Park'
                    },
                    {
                        id: '101',
                        name: 'Jim Green',
                        age: 24,
                        address: 'London No. 1 Lake Park',
                        children: [
                            {
                                id: '10100',
                                name: 'John Brown',
                                age: 18,
                                address: 'New York No. 1 Lake Park'
                            },
                            {
                                id: '10101',
                                name: 'Joe Blackn',
                                age: 30,
                                address: 'Sydney No. 1 Lake Park'
                            },
                            {
                                id: '10102',
                                name: 'Jon Snow',
                                age: 26,
                                address: 'Ottawa No. 2 Lake Park',
                                children: [
                                    {
                                        id: '1010200',
                                        name: 'Jim Green',
                                        age: 24,
                                        address: 'New York No. 1 Lake Park'
                                    }
                                ]
                            }
                        ]
                    },
                    {
                        id: '102',
                        name: 'Joe Black',
                        age: 30,
                        address: 'Sydney No. 1 Lake Park'
                    },
                    {
                        id: '103',
                        name: 'Jon Snow',
                        age: 26,
                        address: 'Ottawa No. 2 Lake Park'
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
        /* height: 120px; */
        margin-top: 5px;
    }

    .label {
        /* padding-top: 5px; */
    }
</style>