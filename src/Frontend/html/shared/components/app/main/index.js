customElements.define('app-main', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    app.component.render.call(this, '#tpl-app-main');
  }
});