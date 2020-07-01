declare global {
    interface RouterMeta {
        title: string;
    }
    interface Router {
        path: string;
        name: string;
        menuIcon?: string;
        icon?: string;
        permission?: string;
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
export const appRouters: Array<Router> = [{
    path: '/setting',
    name: 'setting',
    menuIcon: 'icon-list-2',
    permission: '',
    meta: { title: 'ManageMenu' },
    icon: '&#xe68a;',
    component: main,
    children: [
        { path: 'user', permission: 'Pages.Users', meta: { title: 'Users' }, name: 'user', component: () => import('../views/setting/user/user.vue') },
        { path: 'role', permission: 'Pages.Roles', meta: { title: 'Roles' }, name: 'role', component: () => import('../views/setting/role/role.vue') },
        { path: 'tenant', permission: 'Pages.Tenants', meta: { title: 'Tenants' }, name: 'tenant', component: () => import('../views/setting/tenant/tenant.vue')}
    ]
},
{
    path: '/setting',
    name: '运维服务',
    componentName:'Record',
    menuIcon: 'icon-screen ',
    permission: '',
    meta: { title: '运维服务' },
    icon: '&#xe68a;',
    component: main,
    children: [

        { path: 'question', permission: 'Pages.Tenants', meta: { title: '运维记录' }, name: 'question', component: () => import('../views/setting/questions/record.vue')  }
    ]
},
{
    path: '/outpatient-department',
    name: '门诊系统',
    permission: '',
    menuIcon: 'icon-drawer-2 ',
    componentName:'Prescription',
    meta: { title: '门诊系统' },
    icon: '&#xe68a;',
    component: main,
    children: [

        { path: 'outpatient-prescription', permission: 'Pages.Tenants', meta: { title: '门诊医生站' }, name: 'outpatient-prescription', component: () => import('../views/outpatient/prescription.vue')  }
    ]
}
// ,
// {
//     path: '/inpatient-department',
//     name: '住院系统',
//     permission: '',
//     meta: { title: '住院系统' },
//     icon: '&#xe68a;',
//     component: main,
//     children: [

//         { path: 'patient-registt', permission: 'Pages.Tenants', meta: { title: '住院处' }, name: 'patient-regist', component: () => import('../views/setting/questions/record.vue')  },
//         { path: 'expense-clearing1', permission: 'Pages.Tenants', meta: { title: '出院结算' }, name: 'expense-clearing1', component: () => import('../views/setting/questions/record.vue')  },
//         { path: 'expense-clearing2', permission: 'Pages.Tenants', meta: { title: '住院护士站' }, name: 'expense-clearing2', component: () => import('../views/setting/questions/record.vue')  },
//         { path: 'expense-clearing3', permission: 'Pages.Tenants', meta: { title: '医生工作站' }, name: 'expense-clearing3', component: () => import('../views/setting/questions/record.vue')  },
//         { path: 'expense-clearing4', permission: 'Pages.Tenants', meta: { title: '住院服务中心' }, name: 'expense-clearing4', component: () => import('../views/inpatient-department/leave-hospital/expense-clearing.vue')  }
//     ]
// },
// {
//     path: '/emergency-department',
//     name: '急诊系统',
//     permission: '',
//     meta: { title: '急诊系统' },
//     icon: '&#xe68a;',
//     component: main,
//     children: [

//         { path: 'patient-registt', permission: 'Pages.Tenants', meta: { title: '住院处' }, name: 'patient-regist', component: () => import('../views/inpatient-department/inpatient-registration/patient-regist.vue')  },
//         { path: 'expense-clearing5', permission: 'Pages.Tenants', meta: { title: '出院结算' }, name: 'expense-clearing5', component: () => import('../views/inpatient-department/leave-hospital/expense-clearing.vue')  },
//         { path: 'expense-clearing6', permission: 'Pages.Tenants', meta: { title: '住院护士站' }, name: 'expense-clearing6', component: () => import('../views/inpatient-department/leave-hospital/expense-clearing.vue')  },
//         { path: 'expense-clearing7', permission: 'Pages.Tenants', meta: { title: '医生工作站' }, name: 'expense-clearing7', component: () => import('../views/inpatient-department/leave-hospital/expense-clearing.vue')  },
//         { path: 'expense-clearing8', permission: 'Pages.Tenants', meta: { title: '住院服务中心' }, name: 'expense-clearing8', component: () => import('../views/inpatient-department/leave-hospital/expense-clearing.vue')  }
//     ]
// },
// {
//     path: '/emergency-department',
//     name: '医技系统',
//     permission: '',
//     meta: { title: '医技系统' },
//     icon: '&#xe68a;',
//     component: main,
//     children: [

//         { path: 'patient-registt', permission: 'Pages.Tenants', meta: { title: '住院处' }, name: 'patient-regist', component: () => import('../views/inpatient-department/inpatient-registration/patient-regist.vue')  },
//         { path: 'expense-clearing9', permission: 'Pages.Tenants', meta: { title: '出院结算' }, name: 'expense-clearing9', component: () => import('../views/inpatient-department/leave-hospital/expense-clearing.vue')  },
//         { path: 'expense-clearing10', permission: 'Pages.Tenants', meta: { title: '住院护士站' }, name: 'expense-clearing10', component: () => import('../views/inpatient-department/leave-hospital/expense-clearing.vue')  },
//         { path: 'expense-clearing11', permission: 'Pages.Tenants', meta: { title: '医生工作站' }, name: 'expense-clearing11', component: () => import('../views/inpatient-department/leave-hospital/expense-clearing.vue')  },
//         { path: 'expense-clearing12', permission: 'Pages.Tenants', meta: { title: '住院服务中心' }, name: 'expense-clearing12', component: () => import('../views/inpatient-department/leave-hospital/expense-clearing.vue')  }
//     ]
// }
]
export const routers = [
    loginRouter,
    locking,
    ...appRouters,
    otherRouters
];
