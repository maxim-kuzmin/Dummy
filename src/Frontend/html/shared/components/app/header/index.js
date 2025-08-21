customElements.define('app-header', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    app.component.render.call(this, '#tpl-app-header');
  }
});