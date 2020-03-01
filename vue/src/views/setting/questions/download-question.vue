<template>
  <div style="width: 700px;">
    <Modal :title="L('下载周报')" :value="value" @on-ok="save" @on-visible-change="visibleChange">
      <a :href="href" download="test">点击下载</a>
    </Modal>
  </div>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "../../../lib/util";
import AbpBase from "../../../lib/abpbase";
import Question from "@/store/entities/question";
import iView from "iview";
import MyUpload from "@/components/common/MyUpload.vue";
@Component
export default class CreateQuestion extends AbpBase {
  @Prop()
  href: string = "";
  @Prop({ type: Boolean, default: true })
  week: boolean = true;
  name: "edit-question";
  images: ["1.jpg", "2.jpg"];
  @Prop({ type: Boolean, default: false }) value: boolean;
  question: Question = new Question();
  save() {
 
  }
  cancel() {
    
  }
  visibleChange(value: boolean) {
            if (!value) {
                this.$emit('input', value);
            }
        }
  tenantRule = {
    
  };
}
</script>