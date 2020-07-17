import Vue from 'vue';
import VueRouter from 'vue-router';
import { routers } from './router';
import iView from 'iview';
import Util from '../lib/util';
import Cookies from 'js-cookie'
import { appRouters, otherRouters } from './router'
const _import = file => require('@/views/' + file ).default// require('./router/_import_production' ) //_import_production 
Vue.use(VueRouter);

const RouterConfig = {
    // mode: 'history',
    routes: routers
};


 
export const router =  new VueRouter(RouterConfig);

router.beforeEach((to, from, next) => {
    iView.LoadingBar.start();
    Util.title(to.meta.title);
    if (Cookies.get('locking') === '1' && to.name !== 'locking') {
        next({
            replace: true,
            name: 'locking'
        });
    } else if (Cookies.get('locking') === '0' && to.name === 'locking') {
        next(false);
    } else {
        if (!Util.abp.session.userId && to.name !== 'login') {
            next({
                name: 'login'
            });
        } else if (!!Util.abp.session.userId && to.name === 'login') {
            Util.title(to.meta.title);
            next({
                name: 'home'
            });
        } else {
            const curRouterObj = Util.getRouterObjByName([otherRouters, ...appRouters], to.name);
            if (curRouterObj && curRouterObj.permission) {
                if (window.abp.auth.hasPermission(curRouterObj.permission)) {
                    Util.toDefaultPage([otherRouters, ...appRouters], to.name, router, next);
                } else {
                    next({
                        replace: true,
                        name: 'error-403'
                    });
                }
            } else {
                Util.toDefaultPage([...routers], to.name, router, next);
            }
        }
    }
});
router.afterEach((to) => {
    // Util.openNewPage(router.app, to.name, to.params, to.query);
    iView.LoadingBar.finish();
    window.scrollTo(0, 0);
});

function filterAsyncRouter(asyncRouterMap: Array<Router>) { //遍历后台传来的路由字符串，转换为组件对象
    const accessedRouters = asyncRouterMap.filter(route => {
        if (route.component) {

            route.component = _import(route.component)
        }
        if (route.children && route.children.length) {
            route.children = filterAsyncRouter(route.children)
        }
        return true
    })

    return accessedRouters
}