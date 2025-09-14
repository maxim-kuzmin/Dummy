<script setup lang="ts">
  import type { CSSProperties } from 'vue'
  import type { Language } from './app-language.types'
import { NuxtLink } from '#components'

  const { locale, locales } = useI18n()
  const switchLocalePath = useSwitchLocalePath()

  const buttonElementRef = useTemplateRef('button')
  const menuElementRef = useTemplateRef('menu')

  const currentLanguageName = computed(
    () => locales.value.find((x) => x.code === locale.value)?.name,
  )

  const languages = computed(() =>
    locales.value.map(
      (x) =>
        ({
          code: x.code,
          name: x.name,
          url: switchLocalePath(x.code),
          selected: x.code === locale.value,
        }) as Language,
    )
  )

  const isMenuOpen = ref(false)

  const menuStyle = computed(
    () =>
      ({
        visibility: isMenuOpen.value ? 'visible' : 'hidden',
      }) as CSSProperties,
  )

  onMounted(() => {
    if (globalThis.addEventListener) {
      globalThis.addEventListener('click', handleWindowClick);
    }
  })

  onUnmounted(() => {
    if (globalThis.removeEventListener) {
      globalThis.removeEventListener('click', handleWindowClick);
    }
  })

  function handleWindowClick(ev: MouseEvent): void {
    const buttonElement = buttonElementRef.value;
    const menuElement = menuElementRef.value;

    if (!buttonElement || !menuElement) {
      return;
    }

    if (ev.target === buttonElement) {
      isMenuOpen.value = !isMenuOpen.value;
    } else if (ev.target !== menuElement) {
      isMenuOpen.value = false;
    }
  }
</script>

<template>
  <nav class="app-language">
    <button ref="button" type="button">
      {{ currentLanguageName }}
    </button>
    <ul ref="menu" :style="menuStyle">
      <li
        v-for="language in languages"
        :key="language.code"
        :data-selected="language.selected || null"
      >
        <NuxtLink :to="language.url">{{ language.name }}</NuxtLink>
      </li>
    </ul>
  </nav>
</template>
