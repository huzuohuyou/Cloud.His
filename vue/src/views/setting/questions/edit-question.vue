<template>
  <div>
    <Modal title="编辑运维记录" :value="value" @on-ok="save" @on-visible-change="visibleChange">
      <Form ref="questionForm" label-position="top" :rules="tenantRule" :model="question">
        <FormItem>
          <Row>
            <Col span="3" style="text-align: center">服务日期</Col>
            <i-col span="9">
              <DatePicker
                v-model="question.date"
                type="date"
                placeholder="Select date"
                style="width: 200px"
              ></DatePicker>
            </i-col>
            <Col span="3" style="text-align: center">电话</Col>
            <i-col span="9">
              <Input v-model="question.phone"></Input>
            </i-col>
          </Row>
        </FormItem>
        <FormItem>
          <Row>
            <Col span="3" style="text-align: center">科室病区</Col>
            <i-col span="9">
              <Input v-model="question.dept"></Input>
            </i-col>
            <Col span="3" style="text-align: center">工号密码</Col>
            <i-col span="9">
              <Input v-model="question.user"></Input>
            </i-col>
          </Row>
        </FormItem>
        <FormItem prop="databaseConnectionString">
          <Row>
            <Col span="3" style="text-align: center">患者编号</Col>
            <i-col span="9">
              <Input v-model="question.ptno"></Input>
            </i-col>
            <Col span="3" style="text-align: center">门诊住院</Col>
            <i-col span="9">
              <RadioGroup v-model="question.kind">
                <Radio :label="1">门诊</Radio>
                <Radio :label="2">住院</Radio>
              </RadioGroup>
            </i-col>
          </Row>
        </FormItem>
        <FormItem prop="databaseConnectionString" required>
          <Row>
            <Col span="3" style="text-align: center">用户身份</Col>
            <i-col span="9">
              <RadioGroup v-model="question.role">
                <Radio :label="1">医生</Radio>
                <Radio :label="2">护士</Radio>
              </RadioGroup>
            </i-col>
            <Col span="3" style="text-align: center">服务类别</Col>
            <i-col span="9">
              <RadioGroup v-model="question.type">
                <Radio :label="1" checked>咨询</Radio>
                <Radio :label="2">解锁</Radio>
                <Radio :label="3">权限</Radio>
                <Radio :label="4">现场</Radio>
              </RadioGroup>
            </i-col>
          </Row>
        </FormItem>
        <FormItem label="服务问题">
          <Input v-model="question.question" type="email" :maxlength="256"></Input>
        </FormItem>
        <FormItem label="问题原因">
          <Input v-model="question.reason" type="email" :maxlength="256"></Input>
        </FormItem>
        <FormItem label="解决方案">
          <Input v-model="question.answer" type="email" :maxlength="256"></Input>
        </FormItem>
        <!-- 格式化代码会导致控件失效！！！ -->
        <FormItem
          label="截图"
          v-if="question.imageArray!== undefined && question.imageArray!== null &&question.imageArray.length>0"
          id="viewer"
        >
          <div class="images" v-viewer.rebuild="{inline: true}" style="height: 200px;">
            <img v-for="src in  question.imageArray" :src="src" :key="src" height="0" />
          </div>
        </FormItem>
      </Form>
      <div slot="footer">
        <Button @click="cancel">{{L('Cancel')}}</Button>
        <Button @click="save" type="primary">{{L('OK')}}</Button>
      </div>
    </Modal>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../../lib/util";
import AbpBase from "../../../lib/abpbase";
import Question from "@/store/entities/question";
import iView from "iview";
import Viewer from "v-viewer";
import MyUpload from "@/components/common/MyUpload.vue";
import myImageViewer from "@/components/common/my-image-viewer.vue";
@Component({
  // 引入子组件
  components: {
    MyUpload,
    myImageViewer
  }
})
export default class EditTenant extends AbpBase {
  name: "edit-question";
  images: ["1.jpg", "2.jpg"];
  @Prop({ type: Boolean, default: false }) value: boolean;
  question: Question = new Question();
  save() {
    (this.$refs.questionForm as any).validate(async (valid: boolean) => {
      if (valid) {
        await this.$store.dispatch({
          type: "question/update",
          data: this.question
        });
        (this.$refs.questionForm as any).resetFields();
        this.$emit("save-success");
        this.$emit("input", false);
      }
    });
  }
  cancel() {
    (this.$refs.questionForm as any).resetFields();
    this.$emit("input", false);
  }
  visibleChange(value: boolean) {
    if (!value) {
      this.$emit("input", value);
    } else {
      this.question = Util.extend(
        true,
        {},
        this.$store.state.question.editQuestion
      );
    }
  }
  tenantRule = {
    // name: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('TenantName')), trigger: 'blur' }],
    // tenancyName: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('TenancyName')), trigger: 'blur' }]
  };
}
</script>