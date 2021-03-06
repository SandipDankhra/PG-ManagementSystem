import { prop,propObject,propArray,required,maxLength,range ,alphaNumeric } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class FlatBase {

//#region flatId Prop
        @prop()
        flatId : number;
//#endregion flatId Prop


//#region flatNumber Prop
        @required()
        @maxLength({value:50})
        @alphaNumeric()
        flatNumber : string;
//#endregion flatNumber Prop


//#region flatName Prop
        @required()
        @maxLength({value:50})
        flatName : string;
//#endregion flatName Prop


//#region address Prop
        @required()
        address : string;
//#endregion address Prop


//#region locality Prop
        @required()
        @maxLength({value:50})
        locality : string;
//#endregion locality Prop


//#region softDelete Prop
        @prop()
        softDelete : boolean;
//#endregion softDelete Prop



}