import Vue from 'vue';
import Vuex from 'vuex';
Vue.use(Vuex);
import app from './modules/app'
import session from './modules/session'
import account from './modules/account'
import user from './modules/user'
import role from './modules/role'
import tenant from './modules/tenant'
import question from './modules/question'
import moudlegroup from './modules/moudlegroup'
import authority from './modules/authority'
import authoritytree from './modules/authority-tree'
import authoritymain from './modules/authority-main'
const store = new Vuex.Store({
    state: {
        //
    },
    mutations: {
        //
    },
    actions: {

    },
    modules: {
        app,
        session,
        account,
        user,
        role,
        tenant,
        question,
        moudlegroup,
        authority,
        authoritytree,
        authoritymain
    }
});

export default store;