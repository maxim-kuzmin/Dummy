const app = (function() {
  const _aSelected = 'data-selected';
  const _vHidden = 'hidden';
  const _vVisible = 'visible';

  return {
    component: {
      getElement(selector) {
        return document.querySelector(`#${this.id} ${selector}`);
      },
      getElements(selector) {
        return document.querySelectorAll(`#${this.id} ${selector}`);
      },
      render(selector) {
        this.outerHTML = document.querySelector(selector).innerHTML.replaceAll('{{ID}}', this.id);
      }
    },
    selection: {
      off() {
        this.removeAttribute(_aSelected);
      },
      on() {
        this.setAttribute(_aSelected, true);
      }
    },
    visibility: {
      off() {
         if (this.style.visibility !== _vHidden) {
          this.style.visibility = _vHidden;
         }
      },
      on() {
         if (this.style.visibility !== _vVisible) {
          this.style.visibility = _vVisible;
         }
      },
      toggle() {
         this.style.visibility = this.style.visibility === _vHidden ? _vVisible : _vHidden;
      }
    },
  }
})();