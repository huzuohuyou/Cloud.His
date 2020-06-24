<template>
    <div class="patinfo-continer">
        <div class="item-continer">
            <Col span="4" class="label">患者编号：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
            <Col span="4" class="label">性别年龄：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
        </div>
        <div class="item-continer">
            <Col span="4" class="label">诊疗科室：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
            <Col span="4" class="label">挂号区分：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
        </div>
        <div class="item-continer">
            <Col span="4" class="label">诊疗区分：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
            <Col span="4" class="label">最近就诊：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
        </div>
       
    </div>
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
  <style>
    .label{
      margin-top: 5px;
      text-align: right;;
    }
    .patinfo-continer {
        background-color: white;
        border-radius: 10px;
        padding: 0,10px;
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        min-width: 420px;
        height: 100%;
        overflow:auto;
        margin-top: 10px;
    }
    .item-continer{
        margin-top: 5px;
        /* margin-top: -45px; */
    }
    .baseinfo {
        margin-top: 10px;
        background-color: white;
        border-radius: 10px;
        padding: 10px;
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        height: 220px;
    }
</style>