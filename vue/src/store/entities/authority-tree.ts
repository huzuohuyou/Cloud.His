import Entity from './entity'
class Meta {
    title:string;
 
}
export default class AuthorityTree extends Entity<number>{
    title:string;
    expand:string;
    selected:string;
    children:Array<AuthorityTree>;
   
}