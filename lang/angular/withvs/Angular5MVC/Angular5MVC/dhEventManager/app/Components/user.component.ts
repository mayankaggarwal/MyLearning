import { Component, OnInit, ViewChild } from "@angular/core";
import { UserService } from "../Service/user.service";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ModalComponent } from "ng2-bs3-modal/ng2-bs3-modal";
import { IUser } from "../Models/user";
import { DBOperation } from "../Shared/DBOperation";
import { Observable } from "rxjs/Rx";