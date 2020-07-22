import { Store, Module, ActionContext } from 'vuex'
import ListModule from './list-module'
import ListState from './list-state'
import Authority from '../entities/authority'
import Ajax from '../../lib/ajax'
import PageResult from '@/store/entities/page-result';
import AuthorityRole from '../entities/authority-role'
import AuthorityTree from '../entities/authority-tree'

interface AuthorityState extends ListState<AuthorityTree> {
    editAuthority: AuthorityRole;
    permissions: Array<string>;
    nodeId: string;
}
class AuthorityRoleModule extends ListModule<AuthorityState, any, AuthorityRole>{
    state = {
        totalCount: 0,
        currentPage: 1,
        pageSize: 10,
        list: new Array<AuthorityRole>(),
        loading: false,
        editAuthority: new AuthorityRole(),
        permissions: new Array<string>(),
    }
    actions = {
        async setRolePermissions(context: ActionContext<AuthorityState, any>, payload: any) {
            console.log( payload.data)
            await Ajax.post('/api/services/app/Authority/SetRolePermissions', payload.data);
        },
        
    };
  
}
const authorityRoleModule = new AuthorityRoleModule();
export default authorityRoleModule;