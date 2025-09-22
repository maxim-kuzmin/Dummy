export type ResourcesTranslateFunction = (
  key: string,
  params?: unknown[] | Record<string, unknown>
) => string;

export interface ResourcesModel {
  translate: ResourcesTranslateFunction;
}
