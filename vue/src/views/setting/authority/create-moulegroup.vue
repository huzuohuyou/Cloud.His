<template>
  <div style="width: 700px;">
    <Modal title="添加模块组" :value="value" @on-ok="save" @on-visible-change="visibleChange">
      <Form ref="moudleGroupForm" label-position="top" :rules="tenantRule" :model="moudlegroup">
        <FormItem>
          <Row>
            <Col span="6" style="text-align: center">模块组名称</Col>
            <i-col span="18">
              <Input v-model="moudlegroup.groupname"></Input>
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
  import MoudleGroup from "@/store/entities/moudle-group";
  import iView from "iview";

  @Component({
    // 引入子组件
    components: {
    }
  })
  export default class CreateMoudleGroup extends AbpBase {
    @Prop({ type: Boolean, default: false }) value: boolean;
    moudlegroup: MoudleGroup = new MoudleGroup();
    save() {
      this.$store.dispatch({
          type: "moudlegroup/create",
          data: this.moudlegroup
        });
      // (this.$refs.moudleGroupForm as any).validate(async (valid: boolean) => {
      //   console.log(valid);
      //   await this.$store.dispatch({
      //     type: "moudlegroup/create",
      //     data: this.moudlegroup
      //   });
      //   (this.$refs.moudleGroupForm as any).resetFields();
      //   this.$emit("save-success");
      //   this.$emit("input", false);
      // });
    }
    cancel() {
      (this.$refs.moudleGroupForm as any).resetFields();
      this.$emit("input", false);
    }
    visibleChange(value: boolean) {
      if (!value) {
        this.$emit("input", value);
      }
    }
    getRecordTime(date) {
    }
    getImagesFormSon(data) {
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