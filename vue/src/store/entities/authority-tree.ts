import Entity from './entity'
class Meta {
    title:string;
 
}
export default class AuthorityTree extends Entity<number>{
    title:string;
    expand:string;
    selected:string;
    moudleName:string;
    father:string;
    name:string;
    path:string;
    menuIcon:string;
    meta:Meta;
    componentName:string;
    component:string;
    permission:string;
    children:Array<AuthorityTree>;
   
}