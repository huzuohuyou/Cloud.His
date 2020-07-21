import {Store,Module,ActionContext} from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import MoudleGroup from '../entities/moudle-group'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import ListMutations from './list-mutations'

interface MoudleGroupState extends ListState<MoudleGroup>{
    editQuestion:MoudleGroup;
    permissions:Array<string>
}
class MoudleGroupModule extends ListModule<MoudleGroupState,any,MoudleGroup>{
    state={
        totalCount:0,
        currentPage:1,
        pageSize:10,
        list: new Array<MoudleGroup>(),
        loading:false,
        editQuestion:new MoudleGroup()
    }
    actions={
        async getAllRecord(context:ActionContext<MoudleGroupState,any>,payload:any){
            console.log(payload.data)
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/question/GetAllQuestion',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<MoudleGroup>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async getAll(context:ActionContext<MoudleGroupState,any>,payload:any){
            context.state.loading=true;
            let reponse=await Ajax.get('/api/services/app/Tenant/GetAll',{params:payload.data});
            context.state.loading=false;
            let page=reponse.data.result as PageResult<MoudleGroup>;
            context.state.totalCount=page.totalCount;
            context.state.list=page.items;
        },
        async create(context:ActionContext<MoudleGroupState,any>,payload:any){
            console.log("payload.data");
            console.log(payload.data);
            await Ajax.post('/api/services/app/Authority/CreateRoot',payload.data);
        },
        async update(context:ActionContext<MoudleGroupState,any>,payload:any){
            await Ajax.put('/api/services/app/Question/UpdateRecord',payload.data);
        },
        async delete(context:ActionContext<MoudleGroupState,any>,payload:any){
            await Ajax.delete('/api/services/app/Question/Delete?Id='+payload.data.id);
        },
        async get(context:ActionContext<MoudleGroupState,any>,payload:any){
            let reponse=await Ajax.get('/api/services/app/Tenant/Get?Id='+payload.id);
            return reponse.data.result as MoudleGroup;
        },
        async download(context:ActionContext<MoudleGroupState,any>,payload:any){
            console.log('week:');
            console.log(payload.data);
            let reponse=await Ajax.get('/api/services/app/Question/Export?week='+payload.data);
            // console.log(reponse.data.result);
            return reponse.data.result ;
        },
    };
    mutations={
        setCurrentPage(state:MoudleGroupState,page:number){
            state.currentPage=page;
        },
        setPageSize(state:MoudleGroupState,pagesize:number){
            state.pageSize=pagesize;
        },
        edit(state:MoudleGroupState,tenant:MoudleGroup){
            state.editQuestion=tenant;
        }
    }
}
const moudlegroupModule=new MoudleGroupModule();
export default moudlegroupModule;