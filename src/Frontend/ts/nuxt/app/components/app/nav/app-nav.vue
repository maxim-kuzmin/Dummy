<script setup lang="ts">
  import { useAppNavComponent } from '~/utils/domain/app/components/nav/app-nav-component.composable'
  import type { AppNavItemsComponentInput } from '~/utils/domain/app/components/nav/items/app-nav-items-component.types'

  const { items } = useAppNavComponent()

  const itemsComponentInput = {
    items: items.value,
  } as AppNavItemsComponentInput
</script>

<template>
  <nav class="app-nav">
    <AppNavItems v-bind="itemsComponentInput" />
  </nav>
</template>
