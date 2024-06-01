import DataGrid, { Properties } from 'devextreme/ui/data_grid';
import {DxDataGridComponent} from "devextreme-angular";

export const loadDefaultDevextremeDataGridOptions = (): void => {
  DataGrid.defaultOptions<Properties>({
    options: {
      allowColumnResizing: true,
      allowColumnReordering: true,
      columnAutoWidth: true,
      headerFilter: { visible: true },
      filterRow: { visible: true },

      searchPanel: {
        visible: true
      },
      paging: { enabled: true, pageSize: 5 },
      pager: {
        displayMode: 'adaptive',
        visible: true,
        allowedPageSizes: [5, 10, 15, 25, 50, 100],
        showInfo: true,
        showPageSizeSelector: true,
        showNavigationButtons: true
      },
      groupPanel: {
        visible: true
      },
      rowAlternationEnabled: true,
      hoverStateEnabled: true,
      columnHidingEnabled: true,
      activeStateEnabled: true,
      editing: {
        allowAdding: false,
        allowDeleting: false,
        allowUpdating: false
      },
      columnChooser: {
        enabled: true
      },
      stateStoring: { enabled: true, savingTimeout: 2000, storageKey: 'dxGrid' }
    }
  });
};

export function getEditedGridRow<T>(
  rowKey: unknown,
  values: Partial<T>,
  gridInstance: DxDataGridComponent,
  key: string = 'id',
): T {
  const rowData = gridInstance.instance
    .getDataSource()
    .items()
    .find((x) => x[key] === rowKey);
  return { ...rowData, ...values };
}

export function getFilteredRequestParams<T>(loadOptions: any): T {
  let params: T = {} as T;
  [
    'skip',
    'take',
    'requireTotalCount',
    'requireGroupCount',
    'sort',
    'filter',
    'totalSummary',
    'group',
    'groupSummary',
  ].forEach((i) => {
    if (i in loadOptions && isNotEmpty(loadOptions[i])) {
      params = { ...params, [i]: JSON.stringify(loadOptions[i]) };
    }
  });

  return params;
}

export function isNotEmpty(value: any): boolean {
  return value !== undefined && value !== null && value !== '';
}
