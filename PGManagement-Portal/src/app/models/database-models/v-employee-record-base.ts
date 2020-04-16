import { prop,propObject,propArray,required,maxLength,range  } from "@rxweb/reactive-form-validators"
import { gridColumn } from "@rxweb/grid"


export class vEmployeeRecordBase {

//#region userId Prop
        @gridColumn({visible: true, columnIndex:0, allowSorting: true, headerKey: 'userId', keyColumn: true})
        userId : number;
//#endregion userId Prop


//#region firstName Prop
        @gridColumn({visible: true, columnIndex:0, allowSorting: true, headerKey: 'firstName', keyColumn: false})
        firstName : string;
//#endregion firstName Prop


//#region lastName Prop
        @gridColumn({visible: true, columnIndex:1, allowSorting: true, headerKey: 'lastName', keyColumn: false})
        lastName : string;
//#endregion lastName Prop


//#region salary Prop
        @gridColumn({visible: true, columnIndex:2, allowSorting: true, headerKey: 'salary', keyColumn: true})
        salary : number;
//#endregion salary Prop


//#region roleName Prop
        @gridColumn({visible: true, columnIndex:3, allowSorting: true, headerKey: 'roleName', keyColumn: false})
        roleName : string;
//#endregion roleName Prop


//#region documentUrl Prop
        @gridColumn({visible: true, columnIndex:4, allowSorting: true, headerKey: 'documentUrl', keyColumn: false})
        documentUrl : string;
//#endregion documentUrl Prop


//#region joinDate Prop
        @gridColumn({visible: true, columnIndex:5, allowSorting: true, headerKey: 'joinDate', keyColumn: false})
        joinDate : any;
//#endregion joinDate Prop


//#region email Prop
        @gridColumn({visible: true, columnIndex:6, allowSorting: true, headerKey: 'email', keyColumn: false})
        email : string;
//#endregion email Prop


//#region mobileNumber Prop
        @gridColumn({visible: true, columnIndex:7, allowSorting: true, headerKey: 'mobileNumber', keyColumn: false})
        mobileNumber : number;
//#endregion mobileNumber Prop


//#region applicationObjectName Prop
        @gridColumn({visible: true, columnIndex:8, allowSorting: true, headerKey: 'applicationObjectName', keyColumn: false})
        applicationObjectName : string;
//#endregion applicationObjectName Prop

}