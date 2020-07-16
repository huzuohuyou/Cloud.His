<template>
  <div style="width: 700px;">
    <Modal title="添加权限" :value="value" @on-ok="save" @on-visible-change="visibleChange">
      <Form ref="questionForm" label-position="top" :rules="tenantRule" :model="entity">
        <FormItem>
          <Row>
            <Col span="3" style="text-align: center">标题 </Col>
            <i-col span="9">
              <Input v-model="entity.title"></Input>
            </i-col>
            <Col span="3" style="text-align: center">路径</Col>
            <i-col span="9">
              <Input v-model="entity.path"></Input>
            </i-col>
          </Row>
        </FormItem>

        <FormItem prop="databaseConnectionString">
          <Row>
            <Col span="3" style="text-align: center">图标</Col>
            <i-col span="9">
              <Input v-model="entity.menuIcon"></Input>
            </i-col>
            <Col span="3" style="text-align: center">组件名称</Col>
            <i-col span="9">
              <Input v-model="entity.componentName"></Input>
            </i-col>
          </Row>
        </FormItem>

        <FormItem prop="databaseConnectionString" required>
          <Row>
            <Col span="3" style="text-align: center">权限</Col>
            <i-col span="9">
              <Input v-model="entity.permission"></Input>
            </i-col>

          </Row>
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
  import Entity from "@/store/entities/authority";
  import iView from "iview";

  @Component({
    // 引入子组件
    components: {
    }
  })
  export default class CreateQuestion extends AbpBase {
    @Prop({ type: Boolean, default: false }) value: boolean;
    entity: Entity = new Entity();
    save() {
      this.entity.father = this.$store.state.authority.nodeId;
      this.$Message.info(this.$store.state.authority.nodeId);
      console.log(this.$store.state.authority.nodeId);
      (this.$refs.questionForm as any).validate(async (valid: boolean) => {
        if (valid) {
          await this.$store.dispatch({
            type: "authority/create",
            data: this.entity
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
      }
    }
    getRecordTime(date) {
      // this.question.date = date;
    }
    getImagesFormSon(data) {
      // this.question.uploadList = data;
    }
    tenantRule = {
      type: [
        {
          required: true,
          message: this.L("FieldIsRequired", undefined, this.L("TenantName")),
          trigger: "blur"
        }
      ]
    };
  }
</script>