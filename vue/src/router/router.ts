import axios from 'axios'
let fakeRouter2: Array<Router> = 
[
    {
        'path': '/setting',
        'name': '权限管理',
        'componentName': 'SettingContiner1',
        'menuIcon': 'icon-list-2',
        'permission': '',
        'sub': true,
        'meta': { 'title': '权限管理', 'keepAlive': false },
        'icon': '&#xe68a;',
        'component': 'main.vue',
        'children': [
            // { 'path': 'user', 'permission': 'Pages.Users', 'meta': { 'title': 'Users', 'keepAlive': false }, 'name': 'user', 'component': 'setting/user/user.vue' },
            // { 'path': 'role', 'permission': 'Pages.Roles', 'meta': { 'title': 'Roles', 'keepAlive': false }, 'name': 'role', 'component': 'setting/role/role.vue' },
            // { 'path': 'authority', 'permission': 'Pages.Roles', 'meta': { 'title': '权限', 'keepAlive': false }, 'name': 'authority', 'component': 'setting/tenant/tenant.vue' },
            // { 'path': 'tenant', 'permission': 'Pages.Tenants', 'meta': { 'title': 'Tenants', 'keepAlive': false }, 'name': 'tenant', 'component': 'setting/tenant/tenant.vue' }
        ]
    }
]
axios.get('http://capinfo.devops.com:21021/api/services/app/Authority/GetRouters').then(function (response) {
        //  for (let value2 of response.data.result) {
        //         if (value2.children.length > 0) {
        //             // item.children = new Array<Router>()
        //             for (let value3 of value2.children) {
        //                 let item1: Router = {
        //                     'path': value3.path,
        //                     'name': value3.componentName,
        //                     'componentName': value3.componentName,
        //                     'menuIcon': value3.menuIcon,
        //                     'permission': '',
        //                     'sub': true,
        //                     'meta': { 'title': value3.title, 'keepAlive': false },
        //                     'icon': '&#xe68a;',
        //                     'component': _import(value3.component),
        //                 }
        //                 fakeRouter2[0].children.push(item1)
                       
        //             }
        //         }
        //  }

}).catch(function (error) {
    alert(error);
});

const _import = file => require('@/views/' + file).default
declare global {
    interface RouterMeta {
        title: string;
        keepAlive?: boolean;
    }
    interface Router {
        path: string;
        name: string;
        menuIcon?: string;
        icon?: string;
        permission?: string;
        modal?: Array<boolean>;
        sub?: boolean;
        meta?: RouterMeta;
        componentName?: string;
        component: any;
        children?: Array<Router>;
    }
    interface System {
        import(request: string): Promise<any>
    }
    var System: System
}

import main from '../views/main.vue'

export const locking = {
    path: '/locking',
    name: 'locking',
    component: () => import('../components/lockscreen/components/locking-page.vue')
};
export const loginRouter: Router = {
    path: '/',
    name: 'login',
    meta: {
        title: 'LogIn'
    },
    component: () => import('../views/login.vue')
};
export const otherRouters: Router = {
    path: '/main',
    name: 'main',

    permission: '',
    meta: { title: 'ManageMenu' },
    component: main,
    children: [
        { path: 'home', meta: { title: 'HomePage' }, name: 'home', component: () => import('../views/home/home.vue') }
    ]
}


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
export const appRouters: Array<Router> = filterAsyncRouter(fakeRouter2);

export const routers = [
    loginRouter,
    locking,
    ...appRouters,
    otherRouters
];
