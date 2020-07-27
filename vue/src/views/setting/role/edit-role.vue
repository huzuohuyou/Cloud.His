<template>
    <div>
        <Modal style="position: fixed;z-index: 999999;" :title="L('EditRole')" :value="value" @on-ok="save" @on-visible-change="visibleChange">
            <Form ref="roleForm" label-position="top" :rules="roleRule" :model="role">
                <Tabs value="detail" @on-click="changeTab">
                    <TabPane :label="L('RoleDetails')" name="detail">
                        <FormItem :label="L('RoleName')" prop="name">
                            <Input v-model="role.name" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('DisplayName')" prop="displayName">
                            <Input v-model="role.displayName" :maxlength="32" :minlength="2"></Input>
                        </FormItem>
                        <FormItem :label="L('Description')" prop="description">
                            <Input v-model="role.description" :maxlength="1024"></Input>
                        </FormItem>
                    </TabPane>
                    <TabPane :label="L('RolePermission')" name="permission">
                        <Tree ref="tree" :data="tree" show-checkbox></Tree>
                    </TabPane>
                </Tabs>
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
    import Role from '@/store/entities/role';
    import AuthorityRole from '@/store/entities/authority-role';
    @Component
    export default class EditRole extends AbpBase {
        @Prop({ type: Boolean, default: false }) value: boolean;
        role: Role = new Role();
        currentTab: string = '';
        get permissions() {
            return this.$store.state.role.permissions
        }
        save() {
            (this.$refs.roleForm as any).validate(async (valid: boolean) => {
                if (valid) {
                    if (this.currentTab == 'permission') {
                        await this.$store.dispatch({
                            type: 'authorityrole/setRolePermissions',
                            data: { RoleId: this.role.id, Authoritys: (this.$refs.tree as any).getCheckedNodes() }
                        });
                    }
                    else {
                        await this.$store.dispatch({
                            type: 'role/update',
                            data: this.role
                        });

                    }



                    (this.$refs.roleForm as any).resetFields();
                    this.$emit('save-success');
                    this.$emit('input', false);
                }
            })
        }
        cancel() {
            (this.$refs.roleForm as any).resetFields();
            this.$emit('input', false);
        }
        get tree() {
            return this.$store.state.authoritytree.list;
        }
        visibleChange(value: boolean) {
            if (!value) {
                this.$emit('input', value);
            } else {
                this.role = Util.extend(true, {}, this.$store.state.role.editRole);
            }
        }
        async changeTab(value) {
            this.currentTab = value;
            if (value == 'permission') {
                console.log(this.role.id)
                this.$store.dispatch({
                    type: "authoritytree/getRolePermissions",
                    data: this.role.id
                });
            }
        }
        roleRule = {
            name: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('RoleName')), trigger: 'blur' }],
            displayName: [{ required: true, message: this.L('FieldIsRequired', undefined, this.L('DisplayName')), trigger: 'blur' }]
        }
    }
</script>