<template>
  <Row>
    <Col span="16">
    <Form :model="formItem" :label-width="80">
      <FormItem label="">
        <Row>
          <Col span="2" style="text-align: right">患者编号：</Col>
          <Col span="6">
          <Input v-model="formItem.ptno" placeholder="Enter something..."></Input>
          </Col>
          <Col span="2" style="text-align: right">挂号日期：</Col>
          <Col span="6">
          <DatePicker type="date" placeholder="Select date" v-model="formItem.regist_date"></DatePicker>
          </Col>
          <Col span="2" style="text-align: right">诊疗科室：</Col>
          <Col span="6">
          <Select v-model="formItem.out_dept">
            <Option value="beijing">New York</Option>
            <Option value="shanghai">London</Option>
            <Option value="shenzhen">Sydney</Option>
          </Select>
          </Col>

        </Row>

      </FormItem>
      <FormItem label="">
        <Row>
          <Col span="2" style="text-align: right">医保卡号：</Col>
          <Col span="6">
          <Input v-model="formItem.card_no" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">读卡操作：</Col>
          <Col span="6">
          <Button type="primary">读取社保卡[F1]</Button>
          </Col>
          <Col span="4">
          <Button type="success">读京医通卡[F2]</Button>
          </Col>
          <Col span="4">
          <Button type="warning">扫描卡、手册[E]</Button>
          </Col>
        </Row>
      </FormItem>
      <FormItem label="">
        <Row>
          <Col span="2" style="text-align: right">患者姓名：</Col>
          <Col span="6">
          <Input v-model="formItem.name" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">证件类型：</Col>
          <Col span="6">
          <Select v-model="formItem.id_type">
            <Option value="beijing">New York</Option>
            <Option value="shanghai">London</Option>
            <Option value="shenzhen">Sydney</Option>
          </Select>
          </Col>
          <Col span="2" style="text-align: right">证件号码：</Col>
          <Col span="6">
          <Input v-model="formItem.id_no" placeholder="Enter something..."></Input>
          </Col>
        </Row>
      </FormItem>
      <FormItem label="">
        <Row>
          <Col span="2" style="text-align: right">性别：</Col>
          <Col span="6">
          <Select v-model="formItem.sex">
            <Option value="beijing">New York</Option>
            <Option value="shanghai">London</Option>
            <Option value="shenzhen">Sydney</Option>
          </Select>
          </Col>

          <Col span="2" style="text-align: right">出生日期：</Col>
          <Col span="6">
          <Input v-model="formItem.birthday" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">年龄：</Col>
          <Col span="6">
          <Input v-model="formItem.age" placeholder="Enter something..."></Input>
          </Col>
        </Row>
      </FormItem>
      <FormItem label="">
        <Row>
          <Col span="2" style="text-align: right">联系地址：</Col>
          <Col span="6">
          <Input v-model="formItem.address" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">婚姻：</Col>
          <Col span="6">
          <Input v-model="formItem.marry" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">民族：</Col>
          <Col span="6">
          <Input v-model="formItem.nation" placeholder="Enter something..."></Input>
          </Col>
        </Row>
      </FormItem>
      <FormItem label="">
        <Row>
          <Col span="2" style="text-align: right">联系方式1：</Col>
          <Col span="6">
          <Input v-model="formItem.tel1" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">联系方式2：</Col>
          <Col span="6">
          <Input v-model="formItem.tel2" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">职业：</Col>
          <Col span="6">
          <Input v-model="formItem.job" placeholder="Enter something..."></Input>
          </Col>
        </Row>
      </FormItem>
      <FormItem label="">
        <Row>
          <Col span="2" style="text-align: right">联系人：</Col>
          <Col span="6">
          <Input v-model="formItem.relation" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">联系人电话：</Col>
          <Col span="6">
          <Input v-model="formItem.relation_tel" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">联系人关系：</Col>
          <Col span="6">
          <Input v-model="formItem.relationship" placeholder="Enter something..."></Input>
          </Col>
        </Row>
      </FormItem>
      <FormItem label="">
        <Row>
          <Col span="2" style="text-align: right">诊疗科室：</Col>
          <Col span="6">
          <Input v-model="formItem.dept" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">诊疗医生：</Col>
          <Col span="6">
          <Input v-model="formItem.doctor" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">诊疗时间：</Col>
          <Col span="6">
          <Input v-model="formItem.treat_date" placeholder="Enter something..."></Input>
          </Col>
        </Row>
      </FormItem>
      <FormItem label="">
        <Row>
          <Col span="2" style="text-align: right">诊疗区分：</Col>
          <Col span="6">
          <Input v-model="formItem.treat_kind" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">挂号区分：</Col>
          <Col span="6">
          <Input v-model="formItem.regist_kind" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">优惠区分：</Col>
          <Col span="6">
          <Input v-model="formItem.free_kind" placeholder="Enter something..."></Input>
          </Col>
        </Row>
      </FormItem>
      <FormItem label="">
        <Row>
          <Col span="2" style="text-align: right">是否收费：</Col>
          <Col span="6">
          <Input v-model="formItem.is_charge" placeholder="Enter something..."></Input>
          </Col>

          <Col span="2" style="text-align: right">免费事由：</Col>
          <Col span="6">
          <Input v-model="formItem.uncharge_reason" placeholder="Enter something..."></Input>
          </Col>


        </Row>
      </FormItem>
      <FormItem>
        <Row>
          <Col span="2" style="text-align: right">医师信息：</Col>
          <Col span="22" style="text-align: right">
          <Table height="200"></Table>
          </Col>


        </Row>

      </FormItem>
    </Form>
    </Col>
    <Col span="8">
    <Form :model="formItem" :label-width="80">
      <FormItem label="">
        <Row>
          <Col span="6" style="text-align: right"> <Button type="primary">挂号</Button></Col>
        </Row>
      </FormItem>
      <FormItem label="">
        <Row>
          <Col span="6" style="text-align: right">收费方式：</Col>
          <Col span="18">
          <RadioGroup v-model="formItem.charge_type">
            <Radio label="现金" disabled></Radio>
            <Radio label="pos机"></Radio>
            <Radio label="京医通"></Radio>
          </RadioGroup>
          </Col>
        </Row>

      </FormItem>
      <FormItem label="">
        <Row>
          <Col span="6" style="text-align: right">收费金额：</Col>
          <Col span="18">
          <Input v-model="formItem.charge" placeholder=""></Input>
          </Col>

        </Row>

      </FormItem>
    </Form>

    </Col>
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