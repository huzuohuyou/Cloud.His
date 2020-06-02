<template>
    <div>
        <Tabs :animated="false">
            <TabPane label="标签一"><registion></registion></TabPane>
            <TabPane label="标签二">标签二的内容</TabPane>
            <TabPane label="标签三">标签三的内容</TabPane>
        </Tabs>
    </div>
</template>
<script lang="ts">
    import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
    import Util from "../../../lib/util";
    import AbpBase from "../../../lib/abpbase";
    import Question from "@/store/entities/question";
    import iView from "iview";
    import registion from "@/components/outpatient/registion.vue";
    
    @Component({
            // 引入子组件
            components: {
                registion
            }
        })
    export default class CreateQuestion extends AbpBase {
      @Prop({ type: Boolean, default: false }) value: boolean;
      question: Question = new Question();
      save() {
        console.log(this.$store);
        (this.$refs.questionForm as any).validate(async (valid: boolean) => {
          if (valid) {
            await this.$store.dispatch({
              type: "question/create",
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
        }
      }
      getRecordTime(date) {
        this.question.date = date;
      }
      getImagesFormSon(data) {
        this.question.uploadList = data;
      }
      tenantRule = {
        type: [
          {
            required: true,
            message: this.L("FieldIsRequired", undefined, this.L("TenantName")),
            trigger: "blur"
          }
        ]
        // tenancyName: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('TenancyName')), trigger: 'blur' }],
        // adminEmailAddress: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('AdminEmailAddress')), trigger: 'blur' }, { type: 'email' }]
      };
    }
    </script>