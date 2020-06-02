<template>
    <Row>
            <Form :model="formItem" :label-width="80">
                <FormItem label="">
                    <Row>
                        <Col span="3" style="text-align: right">患者编号：</Col>
                        <Col span="3">
                            <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                        <Col span="3" style="text-align: right">挂号日期：</Col>
                        <Col span="3">
                            <DatePicker type="date" placeholder="Select date" v-model="formItem.date"></DatePicker>
                        </Col>
                        <Col span="3" style="text-align: right">诊疗科室：</Col>
                        <Col span="3">
                            <Select v-model="formItem.select">
                                <Option value="beijing">New York</Option>
                                <Option value="shanghai">London</Option>
                                <Option value="shenzhen">Sydney</Option>
                            </Select>
                        </Col>
                        
                    </Row>
                    
                </FormItem>
                <FormItem label="">
                    <Row>
                        <Col span="3" style="text-align: right">医保卡号：</Col>
                        <Col span="3">
                            <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                       
                        <Col span="3" style="text-align: right">读卡操作：</Col>
                        <Col span="3">
                            <Button type="primary">读取社保卡[F1]</Button>
                        </Col>
                        <Col span="3">
                            <Button type="success">读京医通卡[F2]</Button>
                        </Col>
                        <Col span="3">
                            <Button type="warning">扫描卡、手册[E]</Button>
                        </Col>
                    </Row>
                </FormItem>
                <FormItem label="">
                     <Col span="3" style="text-align: right">患者姓名：</Col>
                    <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                    </Col>
                    
                    <Col span="3" style="text-align: right">证件类型：</Col>
                    <Col span="3">
                        <Select v-model="formItem.select">
                            <Option value="beijing">New York</Option>
                            <Option value="shanghai">London</Option>
                            <Option value="shenzhen">Sydney</Option>
                        </Select>
                    </Col>
                    <Col span="3" style="text-align: right">证件号码：</Col>
                    <Col span="3">
                    <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                    </Col>
                </FormItem>
                <FormItem label="">
                    <Row>
                        <Col span="3" style="text-align: right">性别：</Col>
                    <Col span="3">
                        <Select v-model="formItem.select">
                            <Option value="beijing">New York</Option>
                            <Option value="shanghai">London</Option>
                            <Option value="shenzhen">Sydney</Option>
                        </Select>
                    </Col>
                
                        <Col span="3" style="text-align: right">出生日期：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                
                        <Col span="3" style="text-align: right">年龄：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    </Row>
                </FormItem>
                <FormItem label="">
                    <Row>
                        <Col span="3" style="text-align: right">联系地址：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                
                        <Col span="3" style="text-align: right">婚姻：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                
                        <Col span="3" style="text-align: right">民族：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    </Row>
                </FormItem>
                <FormItem label="">
                    <Row>
                        <Col span="3" style="text-align: right">联系方式1：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                
                        <Col span="3" style="text-align: right">联系方式2：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                
                        <Col span="3" style="text-align: right">职业：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    </Row>
                </FormItem>
                <FormItem label="">
                    <Row>
                        <Col span="3" style="text-align: right">联系人：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    
                        <Col span="3" style="text-align: right">联系人电话：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    
                        <Col span="3" style="text-align: right">联系人关系：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    </Row>
                </FormItem>
                <FormItem label="">
                    <Row>
                        <Col span="3" style="text-align: right">诊疗科室：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    
                        <Col span="3" style="text-align: right">诊疗医生：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    
                        <Col span="3" style="text-align: right">诊疗时间：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    </Row>
                </FormItem>
                <FormItem label="">
                    <Row>
                        <Col span="3" style="text-align: right">诊疗区分：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    
                        <Col span="3" style="text-align: right">挂号区分：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    
                        <Col span="3" style="text-align: right">优惠区分：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    </Row>
                </FormItem>
                <FormItem label="">
                    <Row>
                        <Col span="3" style="text-align: right">是否收费：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    
                        <Col span="3" style="text-align: right">免费事由：</Col>
                        <Col span="3">
                        <Input v-model="formItem.input" placeholder="Enter something..."></Input>
                        </Col>
                    
                     
                    </Row>
                </FormItem>
                <FormItem>
                    <Row>
                        <Col span="3" style="text-align: right">诊疗科室：</Col>
                        <Col span="15" style="text-align: right"><Table height="200" :columns="columns1" :data="data2"></Table></Col>
                        
                     
                    </Row>
                    
                </FormItem>
            </Form>
       
    </Row>
    
</template>
<script>
    export default {
        data () {
            return {
                formItem: {
                    input: '',
                    select: '',
                    radio: 'male',
                    checkbox: [],
                    switch: true,
                    date: '',
                    time: '',
                    slider: [20, 50],
                    textarea: ''
                }
            }
        }
    }
</script>
