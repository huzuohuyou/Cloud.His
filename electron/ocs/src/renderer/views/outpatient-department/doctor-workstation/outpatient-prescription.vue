<template>
  <div class="outpatient-continer">
    <Tabs :animated="false" class="outpatient-continer">
      <TabPane label="门诊处方作业" class="tab-continer">
        <Prescription></Prescription>
      </TabPane>
      <TabPane label="诊间预约">标签二的内容</TabPane>
      <TabPane label="诊间转诊">标签三的内容</TabPane>
      <TabPane label="退费申请">标签三的内容</TabPane>
    </Tabs>
  </div>
</template>
<script lang="ts">
  import { Component, Vue, Inject, Prop, Watch } from 'vue-property-decorator'
import Util from '../../../lib/util'
import AbpBase from '../../../lib/abpbase'
import Question from '@/store/entities/question'
import iView from 'iview'
import Prescription from '@/components/outpatient/prescription.vue'

@Component({
    // 引入子组件
    components: {
      Prescription
    }
  })
  export default class CreateQuestion extends AbpBase {
    @Prop({ type: Boolean, default: false }) value: boolean;
    question: Question = new Question();
  }
</script>
<style>
  .outpatient-continer {
    height: 100%;
  }
  .tab-continer{
    height: 95%;
  }
</style>