<template>
  <Card dis-hover>
    <div class="page-body">
      <Row>
        <Col span="6">
        <Card dis-hover style="margin-right:10px;height:721px;overflow-y:scroll;">
          <Tree :data="tree" ref="tree" @on-select-change='haha'></Tree>
        </Card>
        </Col>
        <Col span="18">
        <Card dis-hover style="margin-right:10px;">
          <div class="page-body">
            <Form ref="queryForm" :label-width="90" label-position="left" inline>
              <Row :gutter="16">
                <Col span="8">
                <FormItem :label="L('Keyword')+':'" style="width:100%">
                  <Input v-model="pagerequest.keyword"
                    :placeholder="L('RoleName')+'/'+L('DisplayName')+'/'+L('Description')"></Input>
                </FormItem>
                </Col>
              </Row>
              <Row>
                <Button @click="createMoudleGroup" icon="android-add" type="primary">{{L('添加根')}}</Button>
                <Button icon="ios-search" type="primary" @click="create" class="toolbar-btn">{{L('添加节点')}}</Button>
                <Button icon="ios-search" type="primary" @click="getpage" class="toolbar-btn">{{L('Find')}}</Button>
                <Button icon="ios-search" type="primary" @click="close" class="toolbar-btn">{{L('关闭')}}</Button>
              </Row>
            </Form>
          </div>
          <Table :loading="loading" :columns="columns" :no-data-text="L('NoDatas')" border :data="list"></Table>
          <Page show-sizer class-name="fengpage" :total="totalCount" class="margin-top-10" @on-change="pageChange"
            @on-page-size-change="pagesizeChange" :page-size="pageSize" :current="currentPage"></Page>
        </Card>
        </Col>
      </Row>
    </div>
    <CreateMouleGroup v-model="createMoudleGroupModalShow" @save-success="getpage"></CreateMouleGroup>
    <create-authority v-model="createModalShow" @save-success="getpage"></create-authority>
    <edit-authority v-model="editModalShow" @save-success="getpage"></edit-authority>
  </Card>
</template>
<script lang="ts">
  import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
  import Util from "@/lib/util";
  import AbpBase from "@/lib/abpbase";
  import PageRequest from "@/store/entities/page-request";
  import CreateAuthority from "./create-authority.vue";
  import CreateMouleGroup from "./create-moulegroup.vue";
  import EditAuthority from "./edit-authority.vue";
  class PageUserRequest extends PageRequest {
    keyword: string;
    isActive: boolean = null; //nullable
    from: Date;
    to: Date;
  }

  @Component({
    components: { CreateAuthority, EditAuthority, CreateMouleGroup }
  })
  export default class Users extends AbpBase {
    nodeId: string = ''
    edit() {
      this.editModalShow = true;
    }
    //filters
    pagerequest: PageUserRequest = new PageUserRequest();
    creationTime: Date[] = [];

    createModalShow: boolean = false;
    createMoudleGroupModalShow: boolean = false;
    editModalShow: boolean = false;
    get list() {

      return this.$store.state.authority.list;
    }
    get tree() {
      return this.$store.state.authoritytree.list;
    }
    get loading() {
      return this.$store.state.authority.loading;
    }
    create() {
      // this.$Message.info(this.$store.state.authority.nodeId);
      if (
      this.$store.state.authority.nodeId == null 
      || this.$store.state.authority.nodeId == undefined
      || this.$store.state.authority.nodeId == '') {
        this.$Message.info('请选择父节点');
      } else {
        this.createModalShow = true;
      }

    }
    createMoudleGroup() {
      this.createMoudleGroupModalShow = true;
    }
    isActiveChange(val: string) {
      console.log(val);
      if (val === "Actived") {
        this.pagerequest.isActive = true;
      } else if (val === "NoActive") {
        this.pagerequest.isActive = false;
      } else {
        this.pagerequest.isActive = null;
      }
    }
    pageChange(page: number) {
      this.$store.commit("authority/setCurrentPage", page);
      this.getpage();
    }
    pagesizeChange(pagesize: number) {
      this.$store.commit("authority/setPageSize", pagesize);
      this.getpage();
    }
    haha(data) {
      this.$store.state.authority.nodeId = data[0].id;
      this.nodeId = data[0].id;
      this.pagerequest.keyword=data[0].title;
      this.getnode();
    }
    async getnode(){
      this.pagerequest.maxResultCount = this.pageSize;
      this.pagerequest.skipCount = (this.currentPage - 1) * this.pageSize;
      //filters

      if (this.creationTime.length > 0) {
        this.pagerequest.from = this.creationTime[0];
      }
      if (this.creationTime.length > 1) {
        this.pagerequest.to = this.creationTime[1];
      }

      await this.$store.dispatch({
        type: "authority/GetTreePage",
        data: this.pagerequest
      });
      
    }
    async close(){
      this.$Modal.remove()
    }
    async getpage() {
      this.$store.state.authority.nodeId='';
      this.pagerequest.maxResultCount = this.pageSize;
      this.pagerequest.skipCount = (this.currentPage - 1) * this.pageSize;
      //filters

      if (this.creationTime.length > 0) {
        this.pagerequest.from = this.creationTime[0];
      }
      if (this.creationTime.length > 1) {
        this.pagerequest.to = this.creationTime[1];
      }

      await this.$store.dispatch({
        type: "authority/GetTreePage",
        data: this.pagerequest
      });
      this.$store.dispatch({
        type: "authoritytree/GetTree",
        data: this.pagerequest
      });
    }
    get pageSize() {
      return this.$store.state.authority.pageSize;
    }
    get totalCount() {
      return this.$store.state.authority.totalCount;
    }
    get currentPage() {
      return this.$store.state.authority.currentPage;
    }
    columns = [
      {
        title: this.L("标题"),
        fixed: 'left',
        key: "title"
      },
      {
        title: this.L("模块"),
        key: "MoudleName"
      },
      {
        title: this.L("父级"),
        key: "Father"
      },
      {
        title: this.L("路径"),
        key: "Path"
      },
      {
        title: this.L("模块名"),
        key: "ComponentName"
      },
      {
        title: this.L("模块"),
        key: "Component"
      },
      {
        title: this.L("IsActive"),
        render: (h: any, params: any) => {
          return h("span", params.row.isActive ? this.L("Yes") : this.L("No"));
        }
      },
      {
        title: this.L("CreationTime"),
        key: "creationTime",
        render: (h: any, params: any) => {
          return h(
            "span",
            new Date(params.row.creationTime).toLocaleDateString()
          );
        }
      },

      {
        title: this.L("Actions"),
        key: "Actions",
        width: 150,
        fixed: 'right',
        render: (h: any, params: any) => {
          return h("div", [
            h(
              "Button",
              {
                props: {
                  type: "primary",
                  size: "small"
                },
                style: {
                  marginRight: "5px"
                },
                on: {
                  click: () => {
                    this.$store.commit("authority/edit", params.row);
                    this.edit();
                  }
                }
              },
              this.L("Edit")
            ),
            h(
              "Button",
              {
                props: {
                  type: "error",
                  size: "small"
                },
                on: {
                  click: async () => {
                    this.$Modal.confirm({
                      title: this.L("Tips"),
                      content: this.L("确定删除此条权限吗？"),
                      okText: this.L("Yes"),
                      cancelText: this.L("No"),
                      onOk: async () => {
                        await this.$store.dispatch({
                          type: "authority/delete",
                          data: params.row
                        });
                        await this.getpage();
                      }
                    });
                  }
                }
              },
              this.L("Delete")
            )
          ]);
        }
      }
    ];
    async created() {
      this.getpage();
      await this.$store.dispatch({
        type: "user/getRoles"
      });
    }
  }
</script>
<style>
  /* 让方形复选框变成圆形单选框样式，最好在树组件外套一个父盒子，在样式前加父级选择器，以免影响其他树组件*/
  .ivu-checkbox-inner {
    border-radius: 50%;
    display: none;
  }

  .ivu-tree-title-selected,
  .ivu-tree-title-selected:hover {
    background-color: #2d8cf0;
    width: 100%;
    left: -20px;
  }
</style>