declare global {
    interface RouterMeta {
        title: string;
        keepAlive?:boolean;
    }
    interface Router {
        path: string;
        name: string;
        menuIcon?: string;
        icon?: string;
        permission?: string;
        modal?:Array<boolean>;
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
import login from '../views/login.vue'
import home from '../views/home/home.vue'
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
export const appRouters: Array<Router> = [
    {
        path: '/setting',
        name: '权限管理',
        componentName: 'SettingContiner',
        menuIcon: 'icon-list-2',
        permission: '',
        sub: true,
        meta: { title: '权限管理',keepAlive: false },
        icon: '&#xe68a;',
        component: main,
        children: [
            { path: 'user', permission: 'Pages.Users', meta: { title: 'Users',keepAlive: false  }, name: 'user', component: () => import('../views/setting/user/user.vue') },
            { path: 'role', permission: 'Pages.Roles', meta: { title: 'Roles',keepAlive: false  }, name: 'role', component: () => import('../views/setting/role/role.vue') },
            { path: 'tenant', permission: 'Pages.Tenants', meta: { title: 'Tenants',keepAlive: false  }, name: 'tenant', component: () => import('../views/setting/tenant/tenant.vue') }
        ]
    },
    {
        path: '/setting',
        name: '权限管理2',
        componentName: 'SettingContiner',
        menuIcon: 'icon-list-2',
        permission: '',
        sub: true,
        meta: { title: '权限管理3',keepAlive: false },
        icon: '&#xe68a;',
        component: main,
        children: [
            { path: 'user', permission: 'Pages.Users', meta: { title: 'Users',keepAlive: false  }, name: 'user', component: () => import('../views/setting/user/user.vue') },
            { path: 'role', permission: 'Pages.Roles', meta: { title: 'Roles',keepAlive: false  }, name: 'role', component: () => import('../views/setting/role/role.vue') },
            { path: 'tenant', permission: 'Pages.Tenants', meta: { title: 'Tenants',keepAlive: false  }, name: 'tenant', component: () => import('../views/setting/tenant/tenant.vue') }
        ]
    },
    {
        path: '/setting',
        name: '权限管理2',
        componentName: 'SettingContiner2',
        menuIcon: 'icon-list-2',
        permission: '',
        sub: true,
        meta: { title: '权限管理3',keepAlive: false },
        icon: '&#xe68a;',
        component: main,
        children: [
            { path: 'user', permission: 'Pages.Users', meta: { title: 'Users' ,keepAlive: false }, name: 'user', component: () => import('../views/setting/user/user.vue') },
            { path: 'role', permission: 'Pages.Roles', meta: { title: 'Roles',keepAlive: false  }, name: 'role', component: () => import('../views/setting/role/role.vue') },
            { path: 'tenant', permission: 'Pages.Tenants', meta: { title: 'Tenants',keepAlive: false  }, name: 'tenant', component: () => import('../views/setting/tenant/tenant.vue') }
        ]
    },
    {
        path: '/setting',
        name: '权限管理2',
        componentName: 'SettingContiner',
        menuIcon: 'icon-list-2',
        permission: '',
        // sub:true,
        meta: { title: '权限管理2',keepAlive: false },
        icon: '&#xe68a;',
        component: main,
        children: [
            { path: 'user', permission: 'Pages.Users', meta: { title: 'Users',keepAlive: false  }, name: 'user', component: () => import('../views/setting/user/user.vue') },
            { path: 'role', permission: 'Pages.Roles', meta: { title: 'Roles',keepAlive: false  }, name: 'role', component: () => import('../views/setting/role/role.vue') },
            { path: 'tenant', permission: 'Pages.Tenants', meta: { title: 'Tenants',keepAlive: false  }, name: 'tenant', component: () => import('../views/setting/tenant/tenant.vue') }
        ]
    },
    {
        path: '/setting',
        name: '运维服务',
        componentName: 'Record',
        menuIcon: 'icon-screen ',
        permission: '',
        meta: { title: '运维服务',keepAlive: false },
        icon: '&#xe68a;',
        component: main,
        children: [

            { path: 'question', permission: 'Pages.Tenants', meta: { title: '运维记录',keepAlive: false  }, name: 'question', component: () => import('../views/setting/questions/record.vue') }
        ]
    },
    {
        path: '/outpatient-department',
        name: '门诊系统',
        permission: '',
        menuIcon: 'icon-drawer-2 ',
        componentName: 'PrescriptionContiner',
        meta: { title: '门诊系统',keepAlive: false },
        icon: '&#xe68a;',
        component: main,
        children: [

            { path: 'outpatient-prescription', permission: 'Pages.Tenants', meta: { title: '门诊医生站',keepAlive: false  }, name: 'outpatient-prescription', component: () => import('../views/outpatient/prescription.vue') }
        ]
    },
    {
        path: '/outpatient-department',
        name: '门诊系统',
        permission: '',
        menuIcon: 'icon-drawer-2 ',
        sub:true,
        componentName: 'PrescriptionContiner',
        meta: { title: '门诊系统',keepAlive: false },
        icon: '&#xe68a;',
        component: main,
        children: [

            { path: 'outpatient-prescription', permission: 'Pages.Tenants', meta: { title: '门诊医生站',keepAlive: false  }, name: 'outpatient-prescription', component: () => import('../views/outpatient/prescription.vue') }
        ]
    }
    
]
export const routers = [
    loginRouter,
    locking,
    ...appRouters,
    otherRouters
];
