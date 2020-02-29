import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Question​ from '../entities/question'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import ListMutations from './list-mutations'

interface QuestionState extends ListState<Question​>{
    editQuestion:Question​;
    permissions:Array<string>
}
class QuestionModule extends ListModule<QuestionState,any,Question​>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<Question​>(),
        loading:false,
        editQuestion:new Question​()
    }
    actions={
        async getAllRecord(context:ActionContext<QuestionState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/question/GetAllQuestion',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<Question​>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async getAll(context:ActionContext<QuestionState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/Tenant/GetAll',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<Question​>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async create(context:ActionContext<QuestionState,any>,payload:any){
            console.log(payload.data);
            await Ajax.post('/api/services/app/Question/AddRecord',payload.data);
        },
        async update(context:ActionContext<QuestionState,any>,payload:any){
            await Ajax.put('/api/services/app/Question/UpdateRecord',payload.data);
        },
        async delete(context:ActionContext<QuestionState,any>,payload:any){
            await Ajax.delete('/api/services/app/Question/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<QuestionState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/Tenant/Get?Id='+payload.id);
            return reponse.data.result as Question​;
        },
        async download(context:ActionContext<QuestionState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/Question/Export',payload.data);
            // console.log(reponse.data.result);
            return reponse.data.result ;
        },
    };
    mutations={
        setCurrentPage(state:QuestionState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:QuestionState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:QuestionState,tenant:Question​){
            state.editQuestion=tenant;
        }
    }
}
const questionModule=new QuestionModule();
export default questionModule;