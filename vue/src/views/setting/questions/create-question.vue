<template>
    <div style="width: 700px;">
        <Modal :title="L('CreateNewTenant')" :value="value" @on-ok="save" @on-visible-change="visibleChange">
            <Form ref="questionForm" label-position="top" :rules="tenantRule" :model="question">
                <FormItem>
                    <Row>
                        <Col span="3" style="text-align: center">服务日期</Col>
                        <i-col span="9">
                            <DatePicker v-model="question.date" type="date" placeholder="Select date"
                                style="width: 200px"></DatePicker>
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
                            <Input v-model="question.kind"></Input>
                        </i-col>
                    </Row>
                </FormItem>
                <FormItem prop="databaseConnectionString">
                    <Row>
                        <Col span="3" style="text-align: center">用户身份</Col>
                        <i-col span="9">
                            <Input v-model="question.role"></Input>
                        </i-col>
                        <Col span="3" style="text-align: center">服务类别</Col>
                        <i-col span="9">
                            <Input v-model="question.type"></Input>
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
                <FormItem label="截图">
                    <MyUpload v-model="question.uploadList" @func="getImagesFormSon"></MyUpload>
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
    import { Component, Vue, Inject, Prop, Watch } from 'vue-property-decorator';
    import Util from '../../../lib/util'
    import AbpBase from '../../../lib/abpbase'
    import Question from '@/store/entities/question';
    import iView from 'iview';
    import MyUpload from '@/components/common/MyUpload.vue';
    @Component({ // 引入子组件 
        components: {
            MyUpload
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
                        type: 'question/create',
                        data: this.question
                    });
                    (this.$refs.questionForm as any).resetFields();
                    this.$emit('save-success');
                    this.$emit('input', false);
                }
            })
        }
        cancel() {
            (this.$refs.questionForm as any).resetFields();
            this.$emit('input', false);
        }
        visibleChange(value: boolean) {
            if (!value) {
                this.$emit('input', value);
            }
        }
        getImagesFormSon(data) {
            this.question.uploadList = data
        }
        tenantRule = {
            // name: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('TenantName')), trigger: 'blur' }],
            // tenancyName: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('TenancyName')), trigger: 'blur' }],
            // adminEmailAddress: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('AdminEmailAddress')), trigger: 'blur' }, { type: 'email' }]
        }
    }
</script>