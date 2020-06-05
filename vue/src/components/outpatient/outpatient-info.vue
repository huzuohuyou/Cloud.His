<template>
    <div class="left-continer">
        <Row >
            <Col span="4" style="text-align: right">患者编号：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
            <Col span="4" style="text-align: right">性别年龄：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
        </Row>
        <Row class="patinfo-row">
            <Col span="4" style="text-align: right">诊疗科室：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
            <Col span="4" style="text-align: right">挂号区分：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
        </Row>
        <Row class="patinfo-row">
            <Col span="4" style="text-align: right">诊疗区分：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
            <Col span="4" style="text-align: right">最近就诊：</Col>
            <Col span="8">
            <Input placeholder="Enter something..."></Input>
            </Col>
        </Row>
        <Row class="patinfo-row">
            <Button>1</Button>
            <Button>2</Button>
            <Button>3</Button>
            <Button>4</Button>
            <Button>5</Button>
            <Button>6</Button>
            <Button>7</Button>
            <Button>8</Button>
          
            <Button>更多</Button></Row>
    </div>
</template>
  <script>
    export default {
      data() {
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
    .left-continer {
        background-color: white;
        border-radius: 10px;
        padding: 0,10px;
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
        min-width: 420px;
        height: 100%;
        overflow:auto;
    }
    .patinfo-row{
        margin-top: 10px;
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