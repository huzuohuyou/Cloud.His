<template style="z-index: 9;">
  <div>
    <Card dis-hover>
      <div class="page-body">
        <Form ref="queryForm" :label-width=0 label-position="left" inline>
          <Row :gutter="16">
            <Col span="8">
            <FormItem style="width:100%">
              <Input @keyup.enter.native="getpage()" placeholder="问题|原因|解决方案" v-model="pagerequest.keyword">
              <Select v-model="pagerequest.userid" slot="prepend" style="width: 80px">
                <Option value="0">全部</Option>
                <Option value="1">我的</Option>
              </Select>
              <Button type="success" slot="append" @click="getpage" icon="ios-search"></Button>
              </Input>
              <!-- <Input v-model="pagerequest.keyword" @keyup.enter.native="getpage()" on-search="getpage()"  search enter-button="Search" placeholder="Enter something..." /> -->
              <!-- <Input
                  v-model="pagerequest.keyword"
                  :placeholder="L('问题')+' / '+L('原因')+' / '+L('解决方案')"
                ></Input> -->
            </FormItem>
            </Col>
            <Col span="12">
            <Button @click="create" icon="ios-bug-outline" type="primary">{{L('Add')}}</Button>
            <!-- <Button
                icon="ios-search"
                type="primary"
                @click="getpage"
                class="toolbar-btn"
              >{{L('Find')}}</Button> -->
            <Button @click="downloadWeek" class="toolbar-btn" icon="ios-code-download" type="success">本周记录</Button>
            <Button @click="downloadAll" class="toolbar-btn" icon="md-download" type="warning">全部记录</Button>
            </Col>
          </Row>
        </Form>
        <div class="margin-top-0">
          <Table :loading="loading" :columns="columns" :no-data-text="L('NoDatas')" border :data="list"></Table>
          <Page show-sizer class-name="fengpage" :total="totalCount" class="margin-top-10" @on-change="pageChange"
            @on-page-size-change="pagesizeChange" :page-size="pageSize" :current="currentPage"></Page>
        </div>
      </div>
    </Card>
    <week-record :href="downloadUrl" v-model="downloadWeekShow" z-index=99999></week-record>
    <create2-role id="createRole" v-model="createModalShow" :class="{createModalShow:my-modal-parent}"  @save-success="getpage"></create2-role>
    <edit-role v-model="editModalShow" :styles="{background: '#f3f3f3',padding:'0px',}" @save-success="getpage"
      z-index=99999></edit-role>
    <view-role v-model="viewModalShow" @save-success="getpage" z-index=99999></view-role>
  </div>
</template>
<style>
  .my-modal-parent {
    position: fixed;
    z-index: 99999;
  }
</style>
<script lang="ts">
  import { Component, Vue, Inject, Prop, Watch } from "vue-property-decorator";
  import Util from "@/lib/util";
  import AbpBase from "@/lib/abpbase";
  import PageRequest from "@/store/entities/page-request";
  import Create2Role from "./create-question.vue";
  import ViewRole from "./view-question.vue";
  import EditRole from "./edit-question.vue";
  import WeekRecord from "./download-question.vue";
  import layer from "vue-layer";
  class PageRoleRequest extends PageRequest {
    keyword: string = "";
    userid: string = "0";
  }
  @Component({
    components: { Create2Role, EditRole, WeekRecord, ViewRole }
  })
  export default class Roles extends AbpBase {
    
    downloadUrl = "";
    week = true;
    edit() {
      this.editModalShow = true;
    }
    view() {
      this.viewModalShow = true;
    }
    downloadWeek() {
      this.week = true;
      console.log(this.downloadWeekShow);
      const ret = this.$store
        .dispatch({
          type: "question/download",
          data: this.week
        })
        .then(function (response) {
          console.log(response);
          return Promise.resolve(response);
        })
        .then(value => {
          this.downloadUrl = value;
          console.log(value);
        });
      this.downloadWeekShow = true;
    }
    downloadAll() {
      this.week = false;
      console.log(this.downloadWeekShow);
      const ret = this.$store
        .dispatch({
          type: "question/download",
          data: this.week
        })
        .then(function (response) {
          return Promise.resolve(response);
        })
        .then(value => {
          this.downloadUrl = value;
          console.log(value);
        });
      this.downloadWeekShow = true;
    }

    pagerequest: PageRoleRequest = new PageRoleRequest();
    downloadWeekShow: boolean = false;
    createModalShow: boolean = false;
    editModalShow: boolean = false;
    viewModalShow: Boolean = false;
    get list() {
      return this.$store.state.question.list;
    }
    get loading() {
      return this.$store.state.question.loading;
    }
    create() {
      this.createModalShow = true;
    }
    pageChange(page: number) {
      this.$store.commit("question/setCurrentPage", page);
      this.getpage();
    }
    pagesizeChange(pagesize: number) {
      this.$store.commit("question/setPageSize", pagesize);
      this.getpage();
    }
    async getpage() {
      this.pagerequest.maxResultCount = this.pageSize;
      this.pagerequest.skipCount = (this.currentPage - 1) * this.pageSize;

      await this.$store.dispatch({
        type: "question/getAllRecord",
        data: this.pagerequest
      });
    }
    get pageSize() {
      return this.$store.state.question.pageSize;
    }
    get totalCount() {
      return this.$store.state.question.totalCount;
    }
    get currentPage() {
      return this.$store.state.question.currentPage;
    }
    columns = [
    {
        title: this.L("电话"),
        key: "phone",
        width:120
      },
      {
        title: this.L("科室"),
        key: "dept",
        width:120
      },
      {
        title: this.L("问题"),
        key: "question"
      },
      {
        title: this.L("原因"),
        key: "reason"
      },
      {
        title: this.L("解决方案"),
        key: "answer"
      },
      // {
      //   title: this.L("日期"),
      //   key: "date"
      // },
      {
        title: this.L("Actions"),
        key: "Actions",
        width: 200,
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
                    this.$store.commit("question/edit", params.row);
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
                      content: this.L("删除此条运维记录吗？"),
                      okText: this.L("Yes"),
                      cancelText: this.L("No"),
                      onOk: async () => {
                        await this.$store.dispatch({
                          type: "question/delete",
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

    }
  }
</script>