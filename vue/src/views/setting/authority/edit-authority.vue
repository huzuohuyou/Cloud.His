<template>
  <div>
    <Modal :title="L('编辑权限')" :value="value" @on-ok="save" @on-visible-change="visibleChange">
      <Form ref="entityForm" label-position="top" :rules="roleRule" :model="entity">
        <FormItem>
          <Row>
            <Col span="3" style="text-align: center">标题 </Col>
            <i-col span="21">
              <Input v-model="entity.title"></Input>
            </i-col>

          </Row>
        </FormItem>

        <FormItem prop="databaseConnectionString">
          <Row>
            <Col span="3" style="text-align: center">图标</Col>
            <i-col span="21">
              <Input v-model="entity.icon"></Input>
            </i-col>

          </Row>
        </FormItem>
        <FormItem prop="databaseConnectionString">
          <Row>

            <Col span="3" style="text-align: center">组件名称</Col>
            <i-col span="21">
              <Input v-model="entity.componentName"></Input>
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
  import { Component, Vue, Inject, Prop, Watch } from 'vue-property-decorator';
  import Util from '../../../lib/util'
  import AbpBase from '../../../lib/abpbase'
  import Authority from '@/store/entities/authority';
  @Component
  export default class EditAuthority extends AbpBase {
    @Prop({ type: Boolean, default: false }) value: boolean;
    entity: Authority = new Authority();
    get permissions() {
      return this.$store.state.authority.permissions
    }
    save() {
      (this.$refs.entityForm as any).validate(async (valid: boolean) => {
        if (valid) {
          await this.$store.dispatch({
            type: 'authority/update',
            data: this.entity
          });
          (this.$refs.entityForm as any).resetFields();
          this.$emit('save-success');
          this.$emit('input', false);
        }
      })
    }
    cancel() {
      (this.$refs.entityForm as any).resetFields();
      this.$emit('input', false);
    }
    visibleChange(value: boolean) {
      console.log(this.$store.state.authority.editAuthority)
      if (!value) {
        this.$emit('input', value);
      } else {
        this.entity = Util.extend(true, {}, this.$store.state.authority.editAuthority);
      }
    }
    roleRule = {
      name: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('RoleName')), trigger: 'blur' }],
      displayName: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('DisplayName')), trigger: 'blur' }]
    }
  }
</script>