import { Component, OnInit } from "@angular/core";
import { anonymous, middleware, route } from "@rxweb/angular-router";
import { multilingual } from "@rxweb/localization";
import { CoreComponent } from "@rxweb/angular-router";
import { LoggedInMiddleware } from "../../domain/security/middleware/logged-in.middleware";
import {
  XhrContext,
  HttpResponse,
  ResponseFilter,
  AbstractRequestFilter,
  xhrFilter,
  http
} from "@rxweb/http";
import { BrowserStorage } from "src/app/domain/services/browser-storage";
import { FormBuilder, FormGroup } from "@angular/forms";
import { RxHttp } from "@rxweb/http";
import { LoginService } from "./login.service";

import { Router } from "@angular/router";
import { ApplicationBroadcaster } from "src/app/temp-service/application-broadcaster";
import { UserRole } from "@app/models";
import { List } from "@rxweb/generics";
// export class AuthFilter extends AbstractRequestFilter {
//     constructor(private browserStorage: BrowserStorage) { super() }
//     onRequest = (context: XhrContext) => {
//         context.request.headers.Authorization = this.browserStorage.local.get('Authorization');
//         this.onRequestExecuting(context);
//     }
// }
// @xhrFilter()
@anonymous()
@middleware([LoggedInMiddleware])
@multilingual("loginComponent")
@Component({
  templateUrl: "./login.component.html"
})
@http({
  hostKey: "server",
  path: "api/Authentication"
})
export class LoginComponent extends CoreComponent implements OnInit {
  loginFormGroup: FormGroup;
  userroles: List<UserRole>;
  constructor(
    private browserStorage: BrowserStorage,
    private loginService: LoginService,
    private router: Router,
    private formBuilder: FormBuilder,
    private http: RxHttp,
    private applicationBroadcaster: ApplicationBroadcaster
  ) {
    super();
  }
  ngOnInit(): void {
    var auth = this.browserStorage.local.get("auth", false);
    if (auth) {
      this.router.navigate(["dashboard"]);
    }

    // this.browserStorage.local.save('Authentication', '');
    this.loginFormGroup = this.formBuilder.group({
      Email: [""],
      Password: [""]
    });
    // this.http.get({ hostUri: 'https://localhost:44352', path: 'api/Authentication' }).subscribe(t => {
    //     // this.browserStorage.local.save('Authentication', t);
    //     document.cookie = "requestContext='abc'";
    //     this.browserStorage.local.save('auth', t);
    //     console.log(t);
    // })
  }
  login() {
    // console.log(this.browserStorage.local.get('auth'));
    // this.http.post({ hostUri: 'https://localhost:44352', path: 'api/Authentication', body: { email: this.loginFormGroup.controls.email.value, password: this.loginFormGroup.controls.password.value } }).subscribe(t => {
    //     console.log(t);
    // })
    console.log(this.loginFormGroup.value);
    this.loginService.login(this.loginFormGroup.value).subscribe(response => {
      console.log(response);
      if (response.failedLogin) {
        alert("Invalid Email and Password!!!");
      } else {
        // this.showComponent = false;
        document.cookie = "requestContext='abc'";
        this.browserStorage.local.save("auth", response.token, false);
        this.browserStorage.local.save("x-request", response.key);
        this.browserStorage.local.save("userName", response.username);

        this.browserStorage.local.save(
          "userrole",
          JSON.stringify(response.userrole),
          false
        );
        this.browserStorage.local.save("userId", response.userid);
       // this.router.navigate(["dashboard"]);
      this.ngOnInit();
      }
      // this.spin = false;
      // this.routers.navigate(["/users"]);
    },
    // The 2nd callback handles errors.
    err => {
      alert("Invalid Email and Password!!!");
    },
    // The 3rd callback handles the "complete" event.
    () => console.log("observable complete")
    );
  }
}
