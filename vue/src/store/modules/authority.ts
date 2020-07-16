import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Authority from '../entities/authority'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import AuthorityTree from '../entities/authority-tree'

interface AuthorityState extends ListState<AuthorityTree> {
    editAuthority: AuthorityTree;
    permissions: Array<string>;
    nodeId: string;
}
class AuthorityModule extends ListModule<AuthorityState, any, AuthorityTree>{
    state = {
        totalCount: 0,
        currentPage: 1,
        pageSize: 10,
        list: new Array<AuthorityTree>(),
        loading: false,
        editAuthority: new AuthorityTree(),
        permissions: new Array<string>(),
    }
    actions = {
        async GetTreePage(context: ActionContext<AuthorityState, any>, payload: any) {
            context.state.loading = true;
            let reponse = await Ajax.get('/api/services/app/Authority/GetTreePage', { params: payload.data });
            context.state.loading = false;
            let page = reponse.data.result as PageResult<AuthorityTree>;
            context.state.totalCount = page.totalCount;
            context.state.list = page.items;
        },

        async create(context: ActionContext<AuthorityState, any>, payload: any) {
            await Ajax.post('/api/services/app/Authority/Create', payload.data);
        },
        async update(context: ActionContext<AuthorityState, any>, payload: any) {
            await Ajax.put('/api/services/app/Authority/Update', payload.data);
        },
        async delete(context: ActionContext<AuthorityState, any>, payload: any) {
            console.log(payload.data)
            await Ajax.delete('/api/services/app/Authority/Delete?Id=' + payload.data.id+'&father='+payload.data.father);
        },
        async getMainMenu(context: ActionContext<AuthorityState, any>, payload: any) {
            console.log(3)
            console.log('getMainMenu')
            context.state.loading = true;
            let reponse = await Ajax.get('/api/services/app/Authority/GetMainMenu', { params: payload.data });
            context.state.loading = false;
            let page = reponse.data.result as Array<AuthorityTree>;
            context.state.list = page;
            console.log(context.state.list)
        },
        async get(context: ActionContext<AuthorityState, any>, payload: any) {
            let reponse = await Ajax.get('/api/services/app/Role/Get?Id=' + payload.id);
            return reponse.data.result as AuthorityTree;
        },
        async getAllPermissions(context: ActionContext<AuthorityState, any>) {
            let reponse = await Ajax.get('/api/services/app/Role/getAllPermissions');
            context.state.permissions = reponse.data.result.items;
        }
    };
    mutations = {
        setCurrentPage(state: AuthorityState, page: number) {
            state.currentPage = page;
        },
        setPageSize(state: AuthorityState, pagesize: number) {
            state.pageSize = pagesize;
        },
        edit(state: AuthorityState, authority: AuthorityTree) {
            state.editAuthority = authority;
        }
    }
}
const authorityModule = new AuthorityModule();
export default authorityModule;