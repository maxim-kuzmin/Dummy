customElements.define('app-layout', class extends HTMLElement {
  constructor() {
    super();
  }

  connectedCallback() {
    app.component.render.call(this, '#tpl-app-layout');
  }
});