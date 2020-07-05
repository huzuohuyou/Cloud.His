import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Authority from '../entities/authority'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';

interface AuthorityState extends ListState<Authority>{
    editRole:Authority;
    permissions:Array<string>
}
class AuthorityModule extends ListModule<AuthorityState,any,Authority>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<Authority>(),
        loading:false,
        editRole:new Authority(),
        permissions:new Array<string>()
    }
    actions={
        async getAll(context:ActionContext<AuthorityState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/Role/GetAll',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<Authority>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async getAllRecord(context:ActionContext<AuthorityState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/question/GetAllQuestion',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<Authority>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async create(context:ActionContext<AuthorityState,any>,payload:any){
            await Ajax.post('/api/services/app/Role/Create',payload.data);
        },
        async update(context:ActionContext<AuthorityState,any>,payload:any){
            await Ajax.put('/api/services/app/Role/Update',payload.data);
        },
        async delete(context:ActionContext<AuthorityState,any>,payload:any){
            await Ajax.delete('/api/services/app/Role/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<AuthorityState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/Role/Get?Id='+payload.id);
            return reponse.data.result as Authority;
        },
        async getAllPermissions(context:ActionContext<AuthorityState,any>){
            let reponse=await Ajax.get('/api/services/app/Role/getAllPermissions');
            context.state.permissions=reponse.data.result.items;
        }
    };
    mutations={
        setCurrentPage(state:AuthorityState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:AuthorityState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:AuthorityState,role:Authority){
            state.editRole=role;
        }
    }
}
const authorityModule=new AuthorityModule();
export default authorityModule;