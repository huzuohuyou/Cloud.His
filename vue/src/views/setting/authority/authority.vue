<template>
  <Card dis-hover>
    <div class="page-body">
      <Row>
        <Col span="6">
          <Card dis-hover style="margin-right:10px">
            <Tree :data="tree" ref="tree" show-checkbox multiple  check-strictly=true></Tree>
          </Card>
        </Col>
        <Col span="18">
          <Card dis-hover style="margin-right:10px">
            <div class="page-body">
              <Form ref="queryForm" :label-width="90" label-position="left" inline>
                <Row :gutter="16">
                  <Col span="8">
                    <FormItem :label="L('Keyword')+':'" style="width:100%">
                      <Input
                        v-model="pagerequest.keyword"
                        :placeholder="L('RoleName')+'/'+L('DisplayName')+'/'+L('Description')"
                      ></Input>
                    </FormItem>
                  </Col>
                </Row>
                <Row>
                  <Button
                    @click="createMoudleGroup"
                    icon="android-add"
                    type="primary"
                    
                  >{{L('添加模块组')}}</Button>
                   <Button
                    icon="ios-search"
                    type="primary"
                    @click="create"
                    class="toolbar-btn"
                  >{{L('添加模块')}}</Button>
                   <Button
                    icon="ios-search"
                    type="primary"
                    @click="create"
                    class="toolbar-btn"
                  >{{L('添加菜单')}}</Button>
                   <Button
                    icon="ios-search"
                    type="primary"
                    @click="getpage"
                    class="toolbar-btn"
                  >{{L('添加子菜单')}}</Button>
                  <Button
                    icon="ios-search"
                    type="primary"
                    @click="getpage"
                    class="toolbar-btn"
                  >{{L('Find')}}</Button>
                </Row>
              </Form>
            </div>
            <Table
              :loading="loading"
              :columns="columns"
              :no-data-text="L('NoDatas')"
              border
              :data="list"
            ></Table>
            <Page
              show-sizer
              class-name="fengpage"
              :total="totalCount"
              class="margin-top-10"
              @on-change="pageChange"
              @on-page-size-change="pagesizeChange"
              :page-size="pageSize"
              :current="currentPage"
            ></Page>
          </Card>
        </Col>
      </Row>
    </div>
    <CreateMouleGroup v-model="createMoudleGroupModalShow" @save-success="getpage"></CreateMouleGroup>
    <create-user v-model="createModalShow" @save-success="getpage"></create-user>
    <edit-user v-model="editModalShow" @save-success="getpage"></edit-user>
  </Card>
</template>
<script lang="ts">
import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
import Util from "@/lib/util";
import AbpBase from "@/lib/abpbase";
import PageRequest from "@/store/entities/page-request";
import CreateUser from "./create-authority.vue";
import CreateMouleGroup from "./create-moulegroup.vue";
import EditUser from "./edit-authority.vue";
class PageUserRequest extends PageRequest {
  keyword: string;
  isActive: boolean = null; //nullable
  from: Date;
  to: Date;
}

@Component({
  components: { CreateUser, EditUser ,CreateMouleGroup}
})
export default class Users extends AbpBase {
  data2: Array<Object> = [
    
  ];
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
    return this.$store.state.user.list;
  }
  get tree() {
    
    return this.$store.state.authority.tree;
  }
  get loading() {
    return this.$store.state.user.loading;
  }
  create() {
    console.log(this.$refs.tree.getCheckedNodes())
    this.createModalShow = true;
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
    this.$store.commit("user/setCurrentPage", page);
    this.getpage();
  }
  pagesizeChange(pagesize: number) {
    this.$store.commit("user/setPageSize", pagesize);
    this.getpage();
  }
  async getpage() {
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
      type: "authority/getAuthoritys",
      data: this.pagerequest
    });
    console.log("authority/getAll")
     this.$store.dispatch({
      type: "authority/getAll",
      data: this.pagerequest
    });
    this.$store.state.authority.random=Math.ceil(Math.random()*10); 
    console.log(this.$store.state.authority.random);
    console.log(this.$store.state.authority.tree)
  }
  get pageSize() {
    return this.$store.state.user.pageSize;
  }
  get totalCount() {
    return this.$store.state.user.totalCount;
  }
  get currentPage() {
    return this.$store.state.user.currentPage;
  }
  columns = [
    {
      title: this.L("UserName"),
      key: "userName"
    },
    {
      title: this.L("Name"),
      key: "name"
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
      title: this.L("LastLoginTime"),
      render: (h: any, params: any) => {
        return h("span", new Date(params.row.lastLoginTime).toLocaleString());
      }
    },
    {
      title: this.L("Actions"),
      key: "Actions",
      width: 150,
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
                  this.$store.commit("user/edit", params.row);
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
                    content: this.L("DeleteUserConfirm"),
                    okText: this.L("Yes"),
                    cancelText: this.L("No"),
                    onOk: async () => {
                      await this.$store.dispatch({
                        type: "user/delete",
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