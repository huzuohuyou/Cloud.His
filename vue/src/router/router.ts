let fakeRouter2: Array<Router> = 
[
   
]


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
