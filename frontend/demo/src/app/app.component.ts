import {AfterViewInit, ChangeDetectionStrategy, Component, inject, ViewChild} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {getFilteredRequestParams, loadDefaultDevextremeDataGridOptions} from "./utils/dx-grid-helper";
import {DxDataGridComponent, DxDataGridModule} from "devextreme-angular";
import config from "devextreme/core/config";
import CustomStore from "devextreme/data/custom_store";
import {lastValueFrom} from "rxjs";
import {DemoService} from "./openapi/services";
import {UserResponseFilteredResult} from "./openapi/models/user-response-filtered-result";
import {GetUsers$Params} from "./openapi/fn/demo/get-users";

@Component({
  selector: 'app-root',
  standalone: true,
  changeDetection: ChangeDetectionStrategy.OnPush,
  imports: [RouterOutlet, DxDataGridModule],
  template: `<dx-data-grid #grid/>`,
})
export class AppComponent implements AfterViewInit {
  @ViewChild('grid') grid!: DxDataGridComponent;

  userService = inject(DemoService)

  constructor() {
    document.title = 'devexpress-filtering-demo';
    config({ editorStylingMode: 'filled' });
    loadDefaultDevextremeDataGridOptions()
  }

  async ngAfterViewInit(): Promise<void> {
    this.loadCustomDataGridOptions();
  }

  loadCustomDataGridOptions() {
    this.grid.instance.option({
      dataSource: this.getGridDataSource(),
      remoteOperations: true,
      columns: [
        {
          dataField: 'username',
          caption: 'UserName',
        },
        {
          dataField: 'firstname',
          caption: 'FirstName',
        },
        {
          dataField: 'lastname',
          caption: 'LastName',
        },
        { dataField: 'id', caption: 'Id', allowEditing: false }
      ]
    });
  }

  private getGridDataSource(): CustomStore {
    return new CustomStore({
      key: 'id',
      byKey: async (id) => {
      },
      load: async (loadOptions: any): Promise<UserResponseFilteredResult> => {
        const params = getFilteredRequestParams<GetUsers$Params>(loadOptions);
        return await lastValueFrom(this.userService.getUsers({...params}));
      },
      insert: async (values: any): Promise<void> => {
      },
      update: async (rowKey, values) => {
      },
      remove: async (rowKey) => {
      }
    });
  }
}
